using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpTexts : MonoBehaviour
{
    public TMP_Text popUpNameText;
    public TMP_Text popUpDescriptionText;
    
    public void SetPopUpVerse(string text)
    {
        popUpNameText.text = text;
    }

    public void SetPopUpDescriptionText(string text)
    {
        popUpDescriptionText.text = text;
    }
}
