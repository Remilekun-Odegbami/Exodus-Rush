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
    private Vector2 swipeDelta;
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
        // Check for the input system being used and call the appropriate function
        //  HandleNewInputSystem();
        //  HandleOldInputSystem();


      //  transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * horizontalSpeed);

        // Move the player forward
    //    transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);


        // Smoothly move the player towards the target position
      //  transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * horizontalSpeed);


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
            //HandleNewInputSystem();
            //HandleOldInputSystem();
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


    // Handling input with the new Input System
    void HandleNewInputSystem()
    {
        if (Touchscreen.current.primaryTouch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
        {
            tap = true;
            isSwiping = true;
            startTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        }

        if (Touchscreen.current.primaryTouch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Ended ||
            Touchscreen.current.primaryTouch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Canceled)
        {
            isSwiping = false;
            Reset();
        }

        // Calculate swipe distance
        swipeDelta = Vector2.zero;
        if (isSwiping)
        {
            swipeDelta = Touchscreen.current.primaryTouch.position.ReadValue() - startTouchPosition;

            if (swipeDelta.magnitude > 125)
            {
                float x = swipeDelta.x;
                float y = swipeDelta.y;

                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    // Left or Right swipe
                    if (x < 0)

                    {

                        swipeLeft = true;
                        DebugManager.Instance.Log("Swiped Right new Input");
                    }
                    else

                    {

                        swipeRight = true;
                        DebugManager.Instance.Log("Swiped Right new Input");
                    }
                }
                else
                {
                    // Up or Down swipe
                    if (y < 0)
                        swipeDown = true;
                    else
                        swipeUp = true;
                }
                Reset();
            }
        }
    }

    // Handling input with the old Input System
    void HandleOldInputSystem()
    {
        if (Input.touchCount > 0) // Ensure there is at least one touch
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == UnityEngine.TouchPhase.Began) // Explicitly use UnityEngine.TouchPhase
            {
                tap = true;
                isSwiping = true;
                startTouchPosition = touch.position;
            }
            else if (touch.phase == UnityEngine.TouchPhase.Ended || touch.phase == UnityEngine.TouchPhase.Canceled)
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
                        // Left or Right swipe
                        if (x < 0)
                        {

                            swipeLeft = true;
                            DebugManager.Instance.Log("Swiped Left Old Input");
                        }

                        else

                        {

                            swipeRight = true;
                            DebugManager.Instance.Log("Swiped Right Old Input");
                        }
                    }
                    else
                    {
                        // Up or Down swipe
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
                                // Swipe Right
                                //  transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
                                // Swipe Right
                                transform.position += Vector3.right * .7f;
                                // Swipe Right
                             //  targetPosition += Vector3.right * horizontalSpeed; // Adjust the step size
                                  // isSwiping = false; // Reset swipe detection
                                DebugManager.Instance.Log("Swiped Right Mobile");

                            }
                            else if (swipeDelta.x < 0 && transform.position.x > left_limit)
                            {
                                // Swipe Left
                                //  transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
                                // Swipe Right
                                transform.position += Vector3.left * .7f;
                                // Swipe Left
                            //    targetPosition += Vector3.left * horizontalSpeed; // Adjust the step size
                                //    isSwiping = false; // Reset swipe detection
                                DebugManager.Instance.Log("Swiped Left Mobile");

                            }
                        }
                    }
                    break;

                case UnityEngine.TouchPhase.Ended:
                    isSwiping = false;

                    // Tap detection (jump on tap)
                    if (touch.tapCount == 1 && !isJumping)                 
                    {
                        TriggerJump();
                    }
                    break;
            }
            // Clamp the target position to limits
            targetPosition.x = Mathf.Clamp(targetPosition.x, left_limit, right_limit);
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



    void HandleMobileMovement1()
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
                            if (swipeDelta.x > 0 && targetPosition.x < right_limit)
                            {
                                // Swipe Right
                                targetPosition += Vector3.right * 1f; // Move right by one unit
                            }
                            else if (swipeDelta.x < 0 && targetPosition.x > left_limit)
                            {
                                // Swipe Left
                                targetPosition += Vector3.left * 1f; // Move left by one unit
                            }
                        }

                        isSwiping = false; // Stop detecting after swipe
                    }
                    break;

                case UnityEngine.TouchPhase.Ended:
                    isSwiping = false;

                    // Detect tap (jump)
                    if (!isJumping)
                    {
                        TriggerJump();
                    }
                    break;
            }

            // Clamp the target position to limits
           targetPosition.x = Mathf.Clamp(targetPosition.x, left_limit, right_limit);
        }
    }
}

// 1 has .delta time, 2 doesn't
