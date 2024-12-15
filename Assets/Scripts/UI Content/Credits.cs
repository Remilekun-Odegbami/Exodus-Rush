using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Credits
{
    public string heading;
    public string content;

   // public TMP_Text creditHeadingText;
    // public TMP_Text creditDescriptionText;

    public Credits(string heading, string content)
    {
        this.heading = heading;
        this.content = content;
    }

}
