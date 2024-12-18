using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutContent : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;

    public string aboutGameContent = "<b>\n\n\n\n\nGet ready for the race of your life!</b>\n\nExodus Rush is an action-packed endless runner that takes you through thrilling environments, daring obstacles, and heart-racing challenges. Dash, dodge, and collect rewards as you push your skills to the limit in this fast-paced adventure.\n\n<b>Features You’ll Love:</b>\n\nDynamic Levels: Explore unique locations filled with surprises.\n\nImmersive Gameplay: Smooth controls and stunning visuals for an unbeatable experience.\n\nChallenge yourself, beat your high score, and prove you're unstoppable in Exodus Rush. Are you ready to run the distance?";

    private void Start()
    {

        if (scrollRect != null)
        {Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 1;
        }
    }
    public string GetAboutContent()
    {
        return aboutGameContent;
    }
}
