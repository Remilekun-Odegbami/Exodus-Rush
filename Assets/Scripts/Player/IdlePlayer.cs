using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayer : MonoBehaviour
{

    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject playerAnimation;
    public void OnTriggerEnter(Collider other)
    {
        thePlayer.GetComponent<Player>().enabled = true;
        playerAnimation.GetComponent<Animator>().Play("Idle");
        

    }
}
