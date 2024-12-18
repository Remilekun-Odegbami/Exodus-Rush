using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject aboutPanel;
    public GameObject pauseButton;
    public GameObject areYouSurePanel;
    public EndRunSequence endRunSequence;
    [SerializeField] AudioSource MenuPopFX;
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        MenuPopFX.Play();
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

    public void OpenAreYouSurePanel()
    {
        areYouSurePanel.SetActive(true);
        MenuPopFX.Play();
        pausePanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void NoContinueRace()
    {
        areYouSurePanel.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void OpenAboutPage()
    {
        aboutPanel.SetActive(true);
        pausePanel.SetActive(false);
        MenuPopFX.Play();
    }

    public void CloseAboutPage() { 
    
        aboutPanel.SetActive(false);
        pausePanel.SetActive(true);

    }

    IEnumerator GoToMenuPage()
    {
        endRunSequence.fadeOut.SetActive(true);
        areYouSurePanel.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        endRunSequence.gameOverScreen.SetActive(true);
        // SceneManager.LoadScene(1);
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(1);
    }

    public void ExitRace()
    {
        StartCoroutine(GoToMenuPage());
    }
}
