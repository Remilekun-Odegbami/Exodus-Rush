using System.Collections;
using UnityEngine;
using TMPro;
using static HighScoreTable;

public class DistanceCovered : MonoBehaviour
{
    public GameObject distanceDisplay;
    public GameObject distanceEndDisplay;
    public TMP_Text highScoreDisplay;
    public TMP_Text highScoreDisplay2;

    public int distanceRan = 0;
    public static bool addingDistance = false;
    public static float disDisplay = 0.35f;

    private bool isGameOver = false;


    void Update()
    {
        if (!addingDistance && !isGameOver)
        {
            addingDistance = true;
            StartCoroutine(AddingDistance());
        }
    }

    public IEnumerator AddingDistance()
    {
        distanceRan++;

        distanceDisplay.GetComponent<TMP_Text>().text = $"{distanceRan} m";
        distanceEndDisplay.GetComponent<TMP_Text>().text = $"{distanceRan} m";
        highScoreDisplay2.GetComponent<TMP_Text>().text = $"{distanceRan} m";
        yield return new WaitForSeconds(disDisplay);
        addingDistance = false;
    }

    public void GameOver(string playerName)
    {
        isGameOver = true;


        // Retrieve the saved high score
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreDisplay2.text = $"{savedHighScore} m";

        // Check and update high score if needed
        if (distanceRan > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", distanceRan); // Save the new high score
            PlayerPrefs.Save(); // Ensure the data is written

            // Update high score table (if applicable)
            HighScoreTable highScoreTable = FindObjectOfType<HighScoreTable>();
            if (highScoreTable != null)
            {
                highScoreTable.AddHighScoreEntry(distanceRan, playerName);
            }
        }
        else
        {
          //  Debug.Log($"No New High Score. Distance: {distanceRan}, High Score: {savedHighScore}");
        }

        ShowGameOverScreen();
    }

    public void ShowGameOverScreen()
    {
        // Display high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreDisplay.text = $"{highScore} m";
        highScoreDisplay2.text = $"{highScore} m";
    }
}
