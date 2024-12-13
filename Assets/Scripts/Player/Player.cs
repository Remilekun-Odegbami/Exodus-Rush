using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 5;
    public float horizontalSpeed = 3;
    public float right_limit = 5.5f;
    public float left_limit = -5.5f;
    public float jumpHeight = 3;

    static public bool canMove = false;
    public bool isJumping = false;
    public bool comingDown = false;

    public GameObject playerObject;
    public static GameObject thePlayer;

    private void Awake()
    {
        thePlayer = this.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        // to push the player forward relative to the world around it and the game speed
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        if (canMove == true)
        {
            // A check to see if we are pressing the correct key
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // to make the player not roll out of the floor limit
            if(this.gameObject.transform.position.x > left_limit) { 
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if(this.gameObject.transform.position.x < right_limit)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
                }
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                if(isJumping == false)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(JumpSequence());
                }
            }
        }
        if(isJumping == true)
        {
            if(comingDown == false)
            {
                // transform the position of the player
                transform.Translate(Vector3.up * Time.deltaTime * jumpHeight, Space.World);
            }
            else if (comingDown == true)
            {
                // transform the position of the player
                transform.Translate(Vector3.up * Time.deltaTime * - jumpHeight, Space.World);
            }
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(.45f);
        comingDown = true;        
        yield return new WaitForSeconds(.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Running");
    }
}
