using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 2;
    public float horizontalSpeed = 3;
    public float right_limit = 5.5f;
    public float left_limit = -5.5f;

    // Update is called once per frame
    void Update()
    {
        // to push the player forward relative to the world around it and the game speed
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        // A check to see if we are pressing the correct key
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
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
    }
}
