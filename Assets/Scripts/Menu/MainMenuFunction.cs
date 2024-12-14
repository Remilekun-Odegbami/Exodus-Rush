using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // turn on the game over fade screen animation and show result screen
        //  ///  LoadNextLevel();
        //}

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadNextLevel()
    {
       // StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    //IEnumerator LoadLevel(int levlIndex)
    //{
    //    transition.SetTrigger("Start");
    //    yield return new WaitForSeconds(transitionTime);
    //    SceneManager.LoadScene(levlIndex);
    //    Debug.Log(levlIndex);
    //}
}
