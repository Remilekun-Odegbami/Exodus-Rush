using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour
{
    public TextMeshProUGUI debugText;

    public static DebugManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Log(string message)
    {
        if (debugText != null)
            debugText.text = message;
    }
}
