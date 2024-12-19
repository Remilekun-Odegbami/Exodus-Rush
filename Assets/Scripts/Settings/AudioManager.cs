using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public Toggle bgmToggle; // Toggle for background music
    public Toggle sfxToggle; // Toggle for sound effects

    public AudioSource bgmSource; // Background music AudioSource
    public List<AudioSource> sfxSources; // List of SFX AudioSources

    private void Start()
    {
        // Load saved preferences
        bool isBGMMuted = PlayerPrefs.GetInt("MuteBGM", 0) == 1;
        bool isSFXMuted = PlayerPrefs.GetInt("MuteSFX", 0) == 1;

        // Set initial states
        bgmToggle.isOn = isBGMMuted;
        sfxToggle.isOn = isSFXMuted;
        UpdateBGMMute(isBGMMuted);
        UpdateSFXMute(isSFXMuted);

        // Listen to toggle changes
        bgmToggle.onValueChanged.AddListener(UpdateBGMMute);
        sfxToggle.onValueChanged.AddListener(UpdateSFXMute);
    }

    public void UpdateBGMMute(bool isMuted)
    {
        bgmSource.volume = isMuted ? 0f : 1f; // Adjust BGM volume
        PlayerPrefs.SetInt("MuteBGM", isMuted ? 1 : 0); // Save preference
    }

    public void UpdateSFXMute(bool isMuted)
    {
        foreach (AudioSource sfxSource in sfxSources)
        {
            sfxSource.volume = isMuted ? 0f : 1f; // Adjust SFX volume
        }
        PlayerPrefs.SetInt("MuteSFX", isMuted ? 1 : 0); // Save preference
    }
}




//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class AudioManager : MonoBehaviour
//{
//    public static AudioManager Instance;  // Singleton instance
//    public AudioSource bgmAudioSource;
//    public AudioSource[] sfxAudioSources;  // Array for SFX audio sources
//    public AudioClip splashBGM, mainMenuBGM, gameBGM;  // Different BGMs
//    public AudioClip[] mainMenuSFX, gameSFX;  // Different sound effects for main menu and game

//    private void Awake()
//    {
//        // Singleton pattern to ensure only one instance exists
//        if (Instance == null)
//        {
//            Instance = this;
//            DontDestroyOnLoad(gameObject);  // Makes sure AudioManager persists across scenes
//        }
//        else
//        {
//            Destroy(gameObject);  // Destroy the duplicate AudioManager
//        }

//        SceneManager.sceneLoaded += OnSceneLoaded;  // Subscribe to scene loaded event
//    }

//    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//    {
//        // Set BGM and SFX based on the scene
//        if (scene.name == "SplashScene")
//        {
//            PlayBackgroundMusic(splashBGM);
//            StopAllSFX();  // Stop SFX during splash scene
//        }
//        else if (scene.name == "MainMenu")
//        {
//            PlayBackgroundMusic(mainMenuBGM);
//            PlayMainMenuSFX();
//        }
//        else if (scene.name == "GameScene")
//        {
//            PlayBackgroundMusic(gameBGM);
//            PlayGameSFX();
//        }
//    }

//    public void PlayBackgroundMusic(AudioClip clip)
//    {
//        if (bgmAudioSource != null)
//        {
//            bgmAudioSource.clip = clip;
//            bgmAudioSource.Play();
//        }
//        else
//        {
//            Debug.LogWarning("Background AudioSource is missing or destroyed.");
//        }
//    }

//    public void StopAllSFX()
//    {
//        foreach (AudioSource sfx in sfxAudioSources)
//        {
//            if (sfx != null)
//            {
//                sfx.Stop();
//            }
//        }
//    }

//    public void PlayMainMenuSFX()
//    {
//        if (mainMenuSFX != null && mainMenuSFX.Length > 0)
//        {
//            for (int i = 0; i < sfxAudioSources.Length; i++)
//            {
//                if (sfxAudioSources[i] != null)
//                {
//                    sfxAudioSources[i].clip = mainMenuSFX[0]; // Play first sound effect
//                    sfxAudioSources[i].Play();
//                    break; // Play only one sound at a time for main menu
//                }
//            }
//        }
//        else
//        {
//            Debug.LogWarning("Main menu SFX are missing.");
//        }
//    }

//    public void PlayGameSFX()
//    {
//        if (gameSFX != null && gameSFX.Length > 0)
//        {
//            for (int i = 0; i < sfxAudioSources.Length; i++)
//            {
//                if (sfxAudioSources[i] != null)
//                {
//                    sfxAudioSources[i].clip = gameSFX[i]; // Assign and play each SFX for the game
//                    sfxAudioSources[i].Play();
//                }
//            }
//        }
//        else
//        {
//            Debug.LogWarning("Game SFX are missing.");
//        }
//    }

//    public void UpdateBGMMute(bool isMuted)
//    {
//        if (bgmAudioSource != null)
//        {
//            bgmAudioSource.mute = isMuted;
//        }
//    }

//    public void UpdateSFXMute(bool isMuted)
//    {
//        foreach (AudioSource sfx in sfxAudioSources)
//        {
//            if (sfx != null)
//            {
//                sfx.mute = isMuted;
//            }
//        }
//    }
//}
