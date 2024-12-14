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
        loadFX.Play();
    }
}
