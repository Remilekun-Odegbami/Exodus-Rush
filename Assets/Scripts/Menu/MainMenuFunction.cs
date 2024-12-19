using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] public GameObject aboutMenu;
    [SerializeField] private GameObject creditMenu;
    [SerializeField] private GameObject HighScoreMenu;
    [SerializeField] private GameObject contactMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] AudioSource MenuPopFX;

    public Loading loading;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }  

    public void OpenAboutPage()
    {
        mainMenu.SetActive(false);
        creditMenu.SetActive(false);
        HighScoreMenu.SetActive(false);
        aboutMenu.SetActive(true);
        MenuPopFX.Play();
    }
    public void OpenCreditPage()
    {
        mainMenu.SetActive(false);
        aboutMenu.SetActive(false);
        HighScoreMenu.SetActive(false);
        creditMenu.SetActive(true);
        MenuPopFX.Play();
    }
    public void OpenHighScoreTablePage()
    {
        mainMenu.SetActive(false);
        aboutMenu.SetActive(false);
        creditMenu.SetActive(false);
        HighScoreMenu.SetActive(true);
        MenuPopFX.Play();
    }
    public void OpenContactPage()
    {
        mainMenu.SetActive(false);
        aboutMenu.SetActive(false);
        creditMenu.SetActive(false);
        HighScoreMenu.SetActive(false);
        contactMenu.SetActive(true);
        MenuPopFX.Play();
    }
    public void OpenSettingsPage()
    {
        mainMenu.SetActive(false);
        aboutMenu.SetActive(false);
        creditMenu.SetActive(false);
        HighScoreMenu.SetActive(false);
        contactMenu.SetActive(false);
        settingsMenu.SetActive(true);
        MenuPopFX.Play();
    }


    public void CloseMenuBtn()
    {
        aboutMenu.SetActive(false);
        creditMenu.SetActive(false);
        HighScoreMenu.SetActive(false);
        contactMenu.SetActive(false);
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }


    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game is quitting");
    }
}
