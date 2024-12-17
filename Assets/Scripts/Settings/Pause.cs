using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    //public GameObject liveCoins;
    //public GameObject liveEnemies;
    //public GameObject liveDistance;
    public GameObject pauseButton;
    public EndRunSequence endRunSequence;
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        endRunSequence.liveCoins.SetActive(false);
        endRunSequence.liveEnemies.SetActive(false);
        endRunSequence.liveDistance.SetActive(false);
        Time.timeScale = 0;

    }
    public void Continue()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        endRunSequence.liveCoins.SetActive(true);
        endRunSequence.liveEnemies.SetActive(true);
        endRunSequence.liveDistance.SetActive(true);
        Time.timeScale = 1;
    }
}
