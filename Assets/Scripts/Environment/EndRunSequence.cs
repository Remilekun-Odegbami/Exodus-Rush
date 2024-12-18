using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveCoins;
    public GameObject liveEnemies;
    public GameObject liveDistance;
    public GameObject liveHighScore;
    public GameObject gameOverScreen;
    public GameObject pauseButton;
    public GameObject fadeOut;
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(EndSequence());
    }

    public IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(2f);
        liveCoins.SetActive(false);
        liveEnemies.SetActive(false);
        liveDistance.SetActive(false);
        pauseButton.SetActive(false);
        liveHighScore.SetActive(false);
        gameOverScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        fadeOut.SetActive(true);
        gameOverScreen.SetActive(false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
