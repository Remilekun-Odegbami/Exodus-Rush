using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;



public class CreditContent : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;



    public Credits[] credits = new Credits[]
    {
     new Credits("\n\n\n\n\n\n\n\n\nGame Developer & Designer", "Oluwaremilekun Odegbami"),
        new Credits("Sound (vfx, sfx)", "Mixkit"),
        new Credits("Characters and Animations", "Mixamo"),
        new Credits("UI", "Violet Theme UI"),
        new Credits("Environment", "Potion Junkies\nDynamic Art\nUnity Asset Store"),
        new Credits("Font", "Google Fonts"),
        new Credits("Special Thanks", "TCN Creatives Community Group\nJoy Ajayi\nHabib Oladapo\nJimmy Vegas")

    };

    public Credits GetCredits(int index)
    {
        if (index >= 0 && index < credits.Length)
        {
            Debug.Log(credits[index]);
            return credits[index];
        }
        Debug.LogError("index out of range");
        return null;
    }

    void Start()
    {

        if (scrollRect != null)
        {
            scrollRect.verticalNormalizedPosition = 1;
        }
    }

}
