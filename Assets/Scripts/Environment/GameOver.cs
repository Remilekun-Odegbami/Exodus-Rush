using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void GameIsOver(string playerName)
    {
        // Access the distance covered
        int distanceRan = FindObjectOfType<DistanceCovered>().distanceRan;

        // Load the saved high score
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (distanceRan > savedHighScore)
        {
            // New high score achieved
            PlayerPrefs.SetInt("HighScore", distanceRan);
            PlayerPrefs.Save();

            // Add to high score table
            HighScoreTable highScoreTable = FindObjectOfType<HighScoreTable>();
           // highScoreTable.AddHighScoreEntry(distanceRan, playerName);

            Debug.Log($"New High Score: {distanceRan} m");
        }
        else
        {
            Debug.Log($"Distance: {distanceRan} m. High Score: {savedHighScore} m");
        }
    }

}
