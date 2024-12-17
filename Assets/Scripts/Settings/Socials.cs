using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socials : MonoBehaviour
{
    // Open Social Links. Ensure you add the URL in the editor.
    public void OpenURL(string URL)
    {
        Application.OpenURL(URL);
    }
}
