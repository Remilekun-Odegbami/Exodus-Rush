using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutContent : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;

    public string aboutGameContent = "Get ready for the race of your life! Exodus Rush is an action-packed endless runner that takes you through thrilling environments, daring obstacles, and heart-racing challenges. Dash, dodge, and collect rewards as you push your skills to the limit in this fast-paced adventure.\r\n\r\nFeatures You’ll Love:\r\n\r\nDynamic Levels: Explore unique locations filled with surprises.\r\n\r\nImmersive Gameplay: Smooth controls and stunning visuals for an unbeatable experience.\r\n\r\nChallenge yourself, beat your high score, and prove you're unstoppable in Exodus Rush. Are you ready to run the distance? Get ready for the race of your life! Exodus Rush is an action-packed endless runner that takes you through thrilling environments, daring obstacles, and heart-racing challenges. Dash, dodge, and collect rewards as you push your skills to the limit in this fast-paced adventure.\r\n\r\nFeatures You’ll Love:\r\n\r\nDynamic Levels: Explore unique locations filled with surprises.\r\n\r\nImmersive Gameplay: Smooth controls and stunning visuals for an unbeatable experience.\r\n\r\nChallenge yourself, beat your high score, and prove you're unstoppable in Exodus Rush. Are you ready to run the distance?";

    private void Start()
    {

        if (scrollRect != null)
        {
            scrollRect.verticalNormalizedPosition = 1f;
        }
    }
    public string GetAboutCOntent()
    {
        return aboutGameContent;
    }
}
