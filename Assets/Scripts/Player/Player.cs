using System.Collections;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
using UnityEngine;



public class Player : MonoBehaviour
{
    public float playerSpeed = 8;
    public float horizontalSpeed = 3;
    public float right_limit = 6.5f;
    public float left_limit = -6.5f;
    public float jumpHeight = 5;
    public float groundY = 1f; // Y-coordinate of the ground/road

    public static bool canMove = false;
    private bool isJumping = false;
    private bool comingDown = false;

    public GameObject playerObject;

    public static GameObject thePlayer; 
    private Vector2 startTouchPosition, currentTouchPosition;
    private bool isSwiping = false;
    private Touch touch;
    private Vector3 targetPosition;

    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;

    private void Awake()
    {
        thePlayer = this.gameObject;
    }

    private void Start()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        // Move the player forward only on the Z-axis
        Vector3 forwardMovement = Vector3.forward * Time.deltaTime * playerSpeed;
        transform.position += forwardMovement;

        // Smoothly move the player to the target horizontal position
        if (Mathf.Abs(transform.position.x - targetPosition.x) > 55f) // Small threshold for precision
        {
            float step = horizontalSpeed * Time.deltaTime; // Speed of movement
            transform.position = new Vector3(
                Mathf.MoveTowards(transform.position.x, targetPosition.x, step), // Move directly to target
                transform.position.y,
                transform.position.z
            );
        }

        if (canMove)
        {
            HandleMobileMovement();
            HandleMovement();
        }

        HandleJump(); // Always check jump status
    }

    private void HandleMovement()
    {
        // Move left
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > left_limit)
        {
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            DebugManager.Instance.Log("Swiped Left");
        }

        // Move right
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position.x < right_limit)
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            DebugManager.Instance.Log("Swiped Right");
        }

        // Jump
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && !isJumping)
        {
            TriggerJump();
        }
    }

    private void Reset()
    {
        // Reset the swipe detection flags
        swipeLeft = swipeRight = swipeUp = swipeDown = false;
        tap = false;
    }

    void HandleMobileMovement()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case UnityEngine.TouchPhase.Began:
                    startTouchPosition = touch.position;
                    isSwiping = true;
                    break;

                case UnityEngine.TouchPhase.Moved:
                    if (isSwiping)
                    {
                        currentTouchPosition = touch.position;
                        Vector2 swipeDelta = currentTouchPosition - startTouchPosition;

                        // Horizontal swipe detection
                        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                        {
                            if (swipeDelta.x > 0 && transform.position.x < right_limit)
                            {
                                isJumping = false;
                                // Swipe Right
                                transform.position += Vector3.right * .15f;
                              //  isSwiping = false; // Reset swipe detection
                                DebugManager.Instance.Log("Swiped Right Mobile");
                                isJumping = false;

                            }
                            else if (swipeDelta.x < 0 && transform.position.x > left_limit)
                            {
                                isJumping = false;
                                // Swipe Left
                                transform.position += Vector3.left * .15f;
                              //  isSwiping = false; // Reset swipe detection
                                DebugManager.Instance.Log("Swiped Left Mobile");
                                isJumping = false;
                            }

                        }
                       // isSwiping = false;
                    }
                    break;

                //     case UnityEngine.TouchPhase.Ended:
                //isSwiping = false;

                //// Vertical swipe detection for jump
                //Vector2 swipeDeltaEnd = touch.position - startTouchPosition;
                //if (!isJumping && Mathf.Abs(swipeDeltaEnd.y) > 50 && Mathf.Abs(swipeDeltaEnd.x) < 30) // Adjust thresholds
                //{
                //    TriggerJump();
                //        DebugManager.Instance.Log("Swiped Up to Jump");
                //}
                //break;

                //case UnityEngine.TouchPhase.Ended:
                //    // Tap detection (jump on tap)
                //   // if (touch.tapCount == 1 && !isJumping)
                //    if(!isJumping)
                //    {
                //        TriggerJump();
                //    }
                //    break;
            }
            //if (!isJumping)
            //       {
            //          TriggerJump();
            //       }
        }
    }

    void TriggerJump()
    {
        isJumping = true;
        comingDown = false;
        StartCoroutine(JumpSequence());
    }

    private void HandleJump()
    {
        if (isJumping)
        {
            if (!comingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * jumpHeight, Space.World);
            }
            else
            {
                transform.Translate(Vector3.down * Time.deltaTime * jumpHeight, Space.World);

                // Check if the player has landed on the ground
                if (transform.position.y <= groundY)
                {
                    transform.position = new Vector3(transform.position.x, groundY, transform.position.z);
                    isJumping = false; // Reset jumping state
                    comingDown = false;
                }
            }
        }
    }

    private IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f); // Time for going up
        comingDown = true; // Start coming down
    }

}
