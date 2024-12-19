using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 8;
    public float horizontalSpeed = 3;
    public float right_limit = 5.5f;
    public float left_limit = -5.5f;
    public float jumpHeight = 3;
    public float groundY = 1f; // Y-coordinate of the ground/road

    public static bool canMove = false;
    private bool isJumping = false;
    private bool comingDown = false;

    public GameObject playerObject;
    public static GameObject thePlayer;

    private Vector2 startTouchPosition, currentTouchPosition;
    private Touch touch;
    private bool isSwiping = false;
    public int pixelDistToDetect = 20;
    private bool fingerDown;

    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
   // private bool isDragging = false;
    private Vector2 startTouch, swipeDelta;

    private void Awake()
    {
        thePlayer = this.gameObject;
    }

    private void Update()
    {
        // Move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

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
        }

        // Move right
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position.x < right_limit)
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
        }

        // Jump
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && !isJumping)
        {
            TriggerJump();
        }
    }

    void HandleMobileMovement()
    {
        if (Input.touchCount > 0) // Ensure there is at least one touch
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                tap = true;
                isSwiping = true;
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isSwiping = false;
                Reset();
            }

            // Calculate the swipe distance
            swipeDelta = Vector2.zero;
            if (isSwiping)
            {
                swipeDelta = touch.position - startTouchPosition;

                if (swipeDelta.magnitude > 125)
                {
                    float x = swipeDelta.x;
                    float y = swipeDelta.y;

                    if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        // Left or Right
                        if (x < 0)
                            swipeLeft = true;
                        else
                            swipeRight = true;
                    }
                    else
                    {
                        // Up or Down
                        if (y < 0)
                            swipeDown = true;
                        else
                            swipeUp = true;
                    }
                    Reset();
                }
            }
        }
    }


    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isSwiping=false;
    }

    //void HandleMobileMovement()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        touch = Input.GetTouch(0);

    //        switch (touch.phase)
    //        {
    //            case TouchPhase.Began:
    //                startTouchPosition = touch.position;
    //                isSwiping = true;
    //                break;

    //            case TouchPhase.Moved:
    //                if (isSwiping)
    //                {
    //                    currentTouchPosition = touch.position;
    //                    Vector2 swipeDelta = currentTouchPosition - startTouchPosition;

    //                    // Horizontal swipe detection
    //                    if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
    //                    {
    //                        if (swipeDelta.x > 0 && transform.position.x < right_limit)
    //                        {
    //                            // Swipe Right
    //                            transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
    //                        }
    //                        else if (swipeDelta.x < 0 && transform.position.x > left_limit)
    //                        {
    //                            // Swipe Left
    //                            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
    //                        }
    //                    }
    //                    // Vertical swipe detection (for jump)
    //                    else if (swipeDelta.y > 50 && !isJumping) // Swipe up
    //                    {
    //                        TriggerJump();
    //                    }

    //                    isSwiping = false;
    //                }
    //                break;

    //            case TouchPhase.Ended:
    //                isSwiping = false;

    //                // Tap detection (jump on tap)
    //                if (touch.tapCount == 1 && !isJumping)
    //                {
    //                    TriggerJump();
    //                }
    //                break;
    //        }
    //    }
    //}

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
