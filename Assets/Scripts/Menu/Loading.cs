using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    float time, second;
    [SerializeField] Image FillImage;
    [SerializeField] AudioSource loadFX;

    // Start is called before the first frame update
    void Start()
    {
        second = 5;
         Invoke("LoadGame", 5f);
        StartCoroutine(LoadingSound());

        // Call ToggleAudio here if needed (e.g., based on saved preferences)
        bool isMuted = PlayerPrefs.GetInt("MuteAudio", 0) == 1; // Retrieve saved mute state
       // ToggleAudio(isMuted); // Apply the mute/unmute setting
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 5)
        {
            time += Time.deltaTime;
            FillImage.fillAmount = time/second;
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator LoadingSound()
    {
        yield return new WaitForSeconds(.8f);
        loadFX.Play();
    }
    
    // Inside any script needing to mute/unmute
    //void ToggleAudio(bool mute)
    //{
    //    AudioManager.Instance.UpdateBGMMute(mute); // Mute/Unmute Background Music
    //    AudioManager.Instance.UpdateSFXMute(mute); // Mute/Unmute Sound Effects
    //}

}
