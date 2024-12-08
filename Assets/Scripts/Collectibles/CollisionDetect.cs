using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField] AudioSource collideFX;
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject playerAnimation;
    public GameObject mainCamera;
    private void OnTriggerEnter(Collider other)
    {
        collideFX.Play();

        thePlayer.GetComponent<Player>().enabled = false;
        playerAnimation.GetComponent<Animator>().Play("Stumble Backwards");
        mainCamera.GetComponent<Animator>().enabled = true;
    }
}
