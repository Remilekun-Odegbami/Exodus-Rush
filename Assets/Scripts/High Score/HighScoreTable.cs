using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

//        highScoreEntryList = new List<HighScoreEntry> {
//            new HighScoreEntry { score = 12345, name = "AAA" },
//new HighScoreEntry { score = 54321, name = "BBB" },
//new HighScoreEntry { score = 67890, name = "CCC" },
//new HighScoreEntry { score = 98765, name = "DDD" },
//new HighScoreEntry { score = 23456, name = "EEE" },
//new HighScoreEntry { score = 34567, name = "FFF" },
//new HighScoreEntry { score = 45678, name = "GGG" },
//new HighScoreEntry { score = 87654, name = "HHH" },
//new HighScoreEntry { score = 56789, name = "III" },
//new HighScoreEntry { score = 65432, name = "JJJ" }
//        };

        highScoreEntryTransformList = new List<Transform>();
        string jsonString = PlayerPrefs.GetString("Highscore Table");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        //sorting through to get the score from highest to lowest

        for (int i = 0; i < highScoreEntryList.Count; i++)
        {
            for (int j = i+1; j < highScoreEntryList.Count; j++)
            {
                if (highScoreEntryList[j].score > highScoreEntryList[i].score)
                {
                    //swap
                    HighScoreEntry temp = highScoreEntryList[i];
                    highScoreEntryList[i] = highScoreEntryList[j];
                    highScoreEntryList[j] = temp;
                }
            }
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

    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 60f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        entryTransform.Find("Position").GetComponent<TextMeshProUGUI>().text = (transformList.Count + 1).ToString();
        entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = highScoreEntry.name;
        entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().text = highScoreEntry.score.ToString();

        transformList.Add(entryTransform);
    }

    private class HighScores
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
