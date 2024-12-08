using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownRun;
    public GameObject fadeIn;
    [SerializeField] int counterNum;
    [SerializeField] AudioSource countDownFX;
    [SerializeField] AudioSource timerFX;
    [SerializeField] AudioSource runFX;

    void Start()
    {
        StartCoroutine(countSequence());
      //  StartCoroutine(countSequenceWithTimeFreeze());

    }

    IEnumerator countSequence()
    {
       // Debug.Log(DistanceCovered.disDisplay);
        Player.thePlayer.GetComponent<Player>().enabled = false;
        Player.canMove = false;
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
      //  Debug.Log(DistanceCovered.addingDistance);
      //  DistanceCovered.addingDistance = true;
    }

    IEnumerator countSequenceWithTimeFreeze()
    {
        Time.timeScale = 0;
        //fadeIn.SetActive(true);
        yield return new WaitForSecondsRealtime(.07f);
        timerFX.Play();
        // wait for the one screen to disappear
        yield return new WaitForSecondsRealtime(1f);
        countDownFX.Play();
        countDown3.SetActive(true);
        yield return new WaitForSecondsRealtime(1.2f);
        countDown3.SetActive(false);
        countDown2.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        countDown2.SetActive(false);
        countDown1.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        countDown1.SetActive(false);
       // fadeIn.SetActive(false);
        countDownRun.SetActive(true);
        runFX.Play();
        Player.canMove = true;
        Time.timeScale = 1;
    }


}
