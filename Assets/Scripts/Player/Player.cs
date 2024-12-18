using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 8;
    public float horizontalSpeed = 3;
    public float right_limit = 5.5f;
    public float left_limit = -5.5f;
    public float jumpHeight = 3;

    public static bool canMove = false;
    private bool isJumping = false;
    private bool comingDown = false;


    public GameObject playerObject;
    public static GameObject thePlayer;

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
            HandleMovement();
        }

        if (isJumping)
        {
            HandleJump();
        }
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
            isJumping = true;
            playerObject.GetComponent<Animator>()?.Play("Jump");
            StartCoroutine(JumpSequence());
        }
    }

    private void HandleJump()
    {
        if (!comingDown)
        {
            transform.Translate(Vector3.up * Time.deltaTime * jumpHeight, Space.World);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * jumpHeight, Space.World);
        }
    }

    private IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;

    }

}


