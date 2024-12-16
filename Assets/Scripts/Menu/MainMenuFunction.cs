using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject aboutMenu;
    [SerializeField] private GameObject creditMenu;
    [SerializeField] private GameObject HighScoreMenu;
    [SerializeField] AudioSource MenuPopFX;

    public Loading loading;

    void Update()
    {
       

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }  

    public void OpenAboutPage()
    {
        mainMenu.SetActive(false);
        creditMenu.SetActive(false);
        aboutMenu.SetActive(true);
        MenuPopFX.Play();
    }
    public void CloseAboutPage()
    {
        aboutMenu.SetActive(false);
        creditMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void OpenCreditPage()
    {
        mainMenu.SetActive(false);
        aboutMenu.SetActive(false);
        creditMenu.SetActive(true);
        MenuPopFX.Play();
    }
    public void CloseCreditPage()
    {
        aboutMenu.SetActive(false);
        creditMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void OpenHighScoreTablePage()
    {
        mainMenu.SetActive(false);
        aboutMenu.SetActive(false);
        creditMenu.SetActive(false);
        HighScoreMenu.SetActive(true);
        MenuPopFX.Play();
    }
    public void CloseHighScoreTablePage()
    {
        aboutMenu.SetActive(false);
        creditMenu.SetActive(false);
        HighScoreMenu.SetActive(true);
        mainMenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game is quitting");
    }
}
