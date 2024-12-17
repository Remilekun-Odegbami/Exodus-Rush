using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.VersionControl;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI aboutUIText;
    [SerializeField] private AboutContent aboutContent;
    [SerializeField] private TextMeshProUGUI creditUIText;
    [SerializeField] private CreditContent creditContent;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private ScrollRect scrollRect2;

    private int currentCreditIndex = 0;
    void Start()
    {
        UpdateAboutUI();
        UpdateContentUI(currentCreditIndex);
    }

    // Update is called once per frame
    void UpdateAboutUI()
    {
        if (scrollRect != null)
        {
            scrollRect.verticalNormalizedPosition = 1f;
        }

        if (aboutContent != null && aboutUIText != null)
        {
            aboutUIText.text = aboutContent.aboutGameContent;
        }

    }
    void UpdateContentUI(int index)
    {
        if (scrollRect2 != null)
        {
            scrollRect2.verticalNormalizedPosition = -200f;
        }

        if (creditUIText != null && creditContent != null)
        {
            string combinedCredits = ""; // Start with an empty string

            foreach (Credits credits in creditContent.credits)
            {
                combinedCredits += $"<size=60><b>{credits.heading}</b></size>\n<size=50>{credits.content}</size>\n\n"; // Format each credit
            }

            creditUIText.text = combinedCredits; // Assign the combined string to the TextMeshPro UI text
        }
    }
    
    public void NextCredit()
    {
        if (currentCreditIndex < creditContent.credits.Length - 1)
        {
            currentCreditIndex++;
            UpdateContentUI(currentCreditIndex);
        }
    }

    public void PreviousCredit()
    {
        if (currentCreditIndex > 0)
        {
            currentCreditIndex--;
            UpdateContentUI(currentCreditIndex);
        }
    }
}