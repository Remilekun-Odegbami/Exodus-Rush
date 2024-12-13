using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveCoins;
    public GameObject liveEnemies;
    public GameObject liveDistance;
    public GameObject gameOverScreen;
    public GameObject fadeOut;
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(EndSequence());
    }

  public IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(1.5f);
        liveCoins.SetActive(false);
        liveEnemies.SetActive(false);
        liveDistance.SetActive(false);
        gameOverScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        fadeOut.SetActive(true);
        gameOverScreen.SetActive(false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
