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
        collideFX.Play();

        thePlayer.GetComponent<Player>().enabled = false;
        playerAnimation.GetComponent<Animator>().Play("Stumble Backwards");
        // stop counting the distance when the player falls
        levelControl.GetComponent<DistanceCovered>().enabled = false;
        // make the camera shake
        mainCamera.GetComponent<Animator>().enabled = true;

        var endRunSequence = levelControl.GetComponent<EndRunSequence>();
        if (endRunSequence != null)
        {
            // turn on the game over fade screen animation and show result screen
            StartCoroutine(endRunSequence.EndSequence());
        }
    }
}
