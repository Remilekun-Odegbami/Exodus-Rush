using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private AboutContent aboutContent;
    [SerializeField] private CreditContent creditContent;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private ScrollRect scrollRect2;
    void Start()
    {
        if(aboutContent != null && uiText != null)
        {
            uiText.text = aboutContent.aboutGameContent;
        } 
        if (scrollRect != null)
        {
            scrollRect.verticalNormalizedPosition = 1f;
            scrollRect2.verticalNormalizedPosition = 200f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
