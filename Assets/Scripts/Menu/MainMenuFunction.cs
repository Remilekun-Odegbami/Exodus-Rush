using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    [SerializeField] GameObject levelControl;
    public Animator transition;

    public float transitionTime = 1f;

    void Update()
    {
        var endRunSequence = levelControl.GetComponent<EndRunSequence>();
        if (endRunSequence != null)
        {
            // turn on the game over fade screen animation and show result screen
            StartCoroutine(endRunSequence.EndSequence());
        }

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levlIndex)
    {
        //  yield return new WaitForSeconds(levlIndex);

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levlIndex);
    }
}
