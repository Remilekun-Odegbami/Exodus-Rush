using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    [SerializeField] private GameObject entryContainer;
    [SerializeField] private GameObject entryTemplate;
    private void Awake()
    {
        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 55f;
        for (int i = 0; i < 10; i++)
        {
            GameObject entryGameObject = Instantiate(entryTemplate, entryContainer.transform);
            Transform entryTransform = entryGameObject.transform;
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
        }
    }
}
