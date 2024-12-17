using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownRun;
    public Pause pause;
    public GameObject fadeIn;
    [SerializeField] int counterNum;
    [SerializeField] AudioSource countDownFX;
    [SerializeField] AudioSource timerFX;
    [SerializeField] AudioSource runFX;
    [SerializeField] GameObject levelControl;
    [SerializeField] GameObject playerAnimation;

    void Start()
    {
        StartCoroutine(countSequence());

    }

    IEnumerator countSequence()
    {
        // stop moving the player before the timer counts
        Player.thePlayer.GetComponent<Player>().enabled = false;
        playerAnimation.GetComponent<Animator>().Play("Dwarf Idle");
        // stop counting the distance before the timer counts
        levelControl.GetComponent<DistanceCovered>().enabled = false;
        Player.canMove = false;
        pause.pauseButton.SetActive(false);
      //  DistanceCovered.addingDistance = false;
        yield return new WaitForSeconds(.5f);
        timerFX.Play();
        // wait for the one screen to disappear
        yield return new WaitForSeconds(1f);
        countDownFX.Play();
        countDown3.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDown2.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDown1.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDownRun.SetActive(true);
        runFX.Play();
        Player.canMove = true;
        Player.thePlayer.GetComponent<Player>().enabled = true;
        levelControl.GetComponent<DistanceCovered>().enabled = true;
        playerAnimation.GetComponent<Animator>().Play("Running");
        pause.pauseButton.SetActive(true);
        //  Debug.Log(DistanceCovered.addingDistance);
        //  DistanceCovered.addingDistance = true;
    }


}
