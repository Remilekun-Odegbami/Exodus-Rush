//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CollisionDetect : MonoBehaviour
//{
//    [SerializeField] AudioSource collideFX;
//    [SerializeField] GameObject thePlayer;
//    [SerializeField] GameObject playerAnimation;
//    public GameObject mainCamera;
//   [SerializeField] GameObject levelControl;

//    public void OnTriggerEnter(Collider other)
//    {
//        collideFX.Play();

//        thePlayer.GetComponent<Player>().enabled = false;
//        playerAnimation.GetComponent<Animator>().Play("Stumble Backwards");
//        // stop counting the distance when the player falls
//        levelControl.GetComponent<DistanceCovered>().enabled = false;
//        // make the camera shake
//        mainCamera.GetComponent<Animator>().enabled = true;

//        var endRunSequence = levelControl.GetComponent<EndRunSequence>();
//       var distanceCovered = levelControl.GetComponent<DistanceCovered>();
//        if (endRunSequence != null)
//        {
//            // turn on the game over fade screen animation and show result screen

//            distanceCovered.ShowGameOverScreen();
//            StartCoroutine(endRunSequence.EndSequence());
//           // distanceCovered.ShowGameOverScreen();
//        }
//    }

//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField] AudioSource collideFX;
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject playerAnimation;
    public GameObject mainCamera;
    [SerializeField] GameObject levelControl;

    public void OnTriggerEnter(Collider other)
    {
        // Play collision sound
        if (collideFX != null) collideFX.Play();

        // Disable player controls and trigger animation
        if (thePlayer != null) thePlayer.GetComponent<Player>().enabled = false;
        if (playerAnimation != null) playerAnimation.GetComponent<Animator>().Play("Stumble Backwards");

        // Disable camera shake animation
        if (mainCamera != null) mainCamera.GetComponent<Animator>().enabled = true;

        // Get DistanceCovered and EndRunSequence components
        var distanceCovered = levelControl.GetComponent<DistanceCovered>();
        var endRunSequence = levelControl.GetComponent<EndRunSequence>();

        if (distanceCovered != null)
        {
            // Trigger Game Over logic (save high score and show game over screen)
            distanceCovered.GameOver("PlayerName");
        }

        if (endRunSequence != null)
        {
            // Trigger end run animations and screen fade
            StartCoroutine(endRunSequence.EndSequence());
        }

        // Disable distance tracking only after handling the Game Over sequence
        if (distanceCovered != null)
            distanceCovered.enabled = false;
    }
}

