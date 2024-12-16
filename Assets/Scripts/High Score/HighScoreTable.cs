using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    [SerializeField] public GameObject entryContainer2;
    [SerializeField] public GameObject entryTemplate2;
    private void Awake()
    {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = transform.Find("HighscoreEntryTemplate");
        if (entryTemplate == null)
        {
            Debug.LogError("Could not find HighscoreEntryContainer object.");
            return;
        } else if(entryContainer != null)
        {
            Debug.Log("Found");
        }


        entryTemplate2.gameObject.SetActive(false);
        float templateHeight = 20f;
        for (int i = 0; i < 10; i++)
        {
            // Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            GameObject entryGameObject = Instantiate(entryTemplate2, entryContainer2.transform);
            Transform entryTransform = entryGameObject.transform;
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
        }
    }
}
