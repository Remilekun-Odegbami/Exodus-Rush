using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class HighScoreTable : MonoBehaviour
{
    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;


    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;

    private void Awake()
    {
        if (entryContainer == null || entryTemplate == null)
        {
            Debug.LogError("EntryContainer or EntryTemplate not assigned!");
            return;
        }

        entryTemplate.gameObject.SetActive(false);

        //  AddHighScoreEntry(10000, "RMO");

        highScoreEntryTransformList = new List<Transform>();
        // Try to load high score data from PlayerPrefs
        string jsonString = PlayerPrefs.GetString("Highscore Table", ""); // Use "" as a fallback if key doesn't exist
        HighScores highScores = null;

        if (!string.IsNullOrEmpty(jsonString))
        {
            highScores = JsonUtility.FromJson<HighScores>(jsonString);
        }

        // If no saved data, initialize with a default list
        if (highScores == null || highScores.highScoreEntryList == null)
        {
            highScoreEntryList = new List<HighScoreEntry>
        {
            new HighScoreEntry {  score = 129, name = "Amina" },
            new HighScoreEntry { score = 125, name = "Tunde" },
            new HighScoreEntry { score = 128, name = "Kwame" },
            new HighScoreEntry { score = 123, name = "Fatima" },
            new HighScoreEntry { score = 127, name = "Bola"  },
            new HighScoreEntry { score = 122, name = "Zainab" },
            new HighScoreEntry { score = 126, name = "Olu" },
            new HighScoreEntry { score = 121, name = "Chike"},
            new HighScoreEntry { score = 120, name = "Ngozi" },
            new HighScoreEntry { score = 124, name = "Kofi" }
        };
        }
        else
        {
            highScoreEntryList = highScores.highScoreEntryList;
        }


        //sorting through to get the score from highest to lowest

        if (highScoreEntryList != null)
        {
            for (int i = 0; i < highScoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highScoreEntryList.Count; j++)
                {
                    if (highScoreEntryList[j].score > highScoreEntryList[i].score)
                    {
                        // Swap entries
                        HighScoreEntry temp = highScoreEntryList[i];
                        highScoreEntryList[i] = highScoreEntryList[j];
                        highScoreEntryList[j] = temp;
                    }
                }
            }
        }
        else
        {
            Debug.LogError("HighScoreEntryList is null!");
        }

        // create a high score for each player
        foreach (HighScoreEntry highScoreEntry in highScoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }
        /*
                // to convert the object into a string
                string json= JsonUtility.ToJson(highScoreEntryList);
                PlayerPrefs.SetString("highScoreTable", json);
                PlayerPrefs.Save();
                Debug.Log(PlayerPrefs.GetString("highScoreTable"));
        */
    }

    //private void Awake()
    //{
    //    string jsonString = PlayerPrefs.GetString("Highscore Table", "");
    //    Debug.Log("Loaded High Scores: " + jsonString);

    //    HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

    //    // If no saved data, initialize with a default list
    //    if (highScores == null || highScores.highScoreEntryList == null)
    //    {
    //        Debug.LogWarning("No high score data found. Initializing default high score list.");
    //        highScoreEntryList = new List<HighScoreEntry>
    //        {
    //            new HighScoreEntry {  score = 129, name = "Amina" },
    //            new HighScoreEntry { score = 125, name = "Tunde" },
    //            new HighScoreEntry { score = 128, name = "Kwame" },
    //            new HighScoreEntry { score = 123, name = "Fatima" },
    //            new HighScoreEntry { score = 127, name = "Bola"  },
    //            new HighScoreEntry { score = 122, name = "Zainab" },
    //            new HighScoreEntry { score = 126, name = "Olu" },
    //            new HighScoreEntry { score = 121, name = "Chike"},
    //            new HighScoreEntry { score = 120, name = "Ngozi" },
    //            new HighScoreEntry { score = 124, name = "Kofi" }
    //        };
    //    }
    //    else
    //    {
    //        highScoreEntryList = highScores.highScoreEntryList;
    //    }

    //    if (highScoreEntryList == null || highScoreEntryList.Count == 0)
    //    {
    //        Debug.Log("Initialising default scores.");
    //        highScoreEntryList = new List<HighScoreEntry>
    //{
    //    new HighScoreEntry { score = 129, name = "Amina" },
    //    // Other default scores...
    //};
    //    }

    //}


    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 60f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

        // Add a fixed Y offset of -25
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count - 25);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch(rank)
        {
            default:
                rankString = rank + "th"; break;

            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;

        }

        entryTransform.Find("Position").GetComponent<TextMeshProUGUI>().text = rankString;
        entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = highScoreEntry.name;
        int score = highScoreEntry.score;
        entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().text = score.ToString();

        transformList.Add(entryTransform);

        // set background visible odds and evens, easier to read
        entryTransform.Find("Background").gameObject.SetActive(rank % 2 == 1);

        //highlight first
        if(rank == 1)
        {
            entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("Position").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().color = Color.green;
        }

        // Set trophy
        // Set trophy (Star) based on rank
        Transform starTransform = entryTransform.Find("Star");

        if (starTransform != null)
        {
            UnityEngine.UI.Image starImage = starTransform.GetComponent<UnityEngine.UI.Image>();
            if (starImage != null)
            {
                switch (rank)
                {
                    case 1: // Gold star
                        if (ColorUtility.TryParseHtmlString("#FFD200", out Color goldColor))
                            starImage.color = goldColor;
                        break;
                    case 2: // Silver star
                        if (ColorUtility.TryParseHtmlString("#C0C0C0", out Color silverColor))
                            starImage.color = silverColor;
                        break;
                    case 3: // Bronze star
                        if (ColorUtility.TryParseHtmlString("#CD7F32", out Color bronzeColor))
                            starImage.color = bronzeColor;
                        break;
                    default:
                        starTransform.gameObject.SetActive(false);
                        break;
                }
            }
        }


    }

    //public void AddHighScoreEntry(int score, string name)
    //{
    //    // Create a new highscore entry object
    //    HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };

    //    // Load the saved highscores
    //    string jsonString = PlayerPrefs.GetString("Highscore Table", "");
    //    HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

    //    // Ensure highScores and the highScoreEntryList are not null
    //    if (highScores == null || highScores.highScoreEntryList == null)
    //    {
    //        highScores = new HighScores { highScoreEntryList = new List<HighScoreEntry>() };
    //    }

    //    // Add new entry to highscores
    //    highScores.highScoreEntryList.Add(highScoreEntry);

    //    // Convert the highScores object back to JSON and save it
    //    string json = JsonUtility.ToJson(highScores);
    //    PlayerPrefs.SetString("Highscore Table", json);
    //    PlayerPrefs.Save();
    //}

    public void AddHighScoreEntry(int score, string name)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };

        // Load existing data
        string jsonString = PlayerPrefs.GetString("Highscore Table", "");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        if (highScores == null || highScores.highScoreEntryList == null)
        {
            highScores = new HighScores { highScoreEntryList = new List<HighScoreEntry>() };
        }

        // Add new entry
        highScores.highScoreEntryList.Add(highScoreEntry);

        // Save the updated high score list
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("Highscore Table", json);
        PlayerPrefs.Save();
        Debug.Log("High Scores Saved: " + json);
    }


    public void RefreshHighScoreTable()
    {
        foreach (Transform child in entryContainer)
        {
            Destroy(child.gameObject);
        }
        Awake(); // Rebuilds the table
    }


    [System.Serializable]
    public class HighScores
    {
        public List<HighScoreEntry> highScoreEntryList;
    }

    [System.Serializable]
    public class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
