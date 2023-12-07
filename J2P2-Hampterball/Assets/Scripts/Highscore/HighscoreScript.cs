using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HighscoreScript : MonoBehaviour
{
    [SerializeField] private string highScoreFilePath = "highScore.json";
    private float highScore;
    [SerializeField] public Transform point;
    [SerializeField] public TMP_Text distanceText;
    [SerializeField] public TMP_Text highScoreText;
    [SerializeField] private int numberOfHighScoresToShow = 3; // Number of top scores to display

    private List<float> highScores = new List<float>(); // List to store the high scores
    public float distance;

    void Start()
    {
        
        LoadHighScore(); // Load the highest score when the game starts
        UpdateHighScoreText(); // Update the high score text in the UI
    }

    void Update()
    {
        distance = (point.transform.position - transform.position).magnitude; // Calculate the distance between the point and the object
        distanceText.text = distance.ToString("F1") + "M"; // Update the distance text in the UI

        if (distance > 0 && !highScores.Contains(distance)) // Check if the current distance is greater than 0 and not already in the high scores list
        {
            highScores.Add(distance); // Add the current distance to the high scores list
            highScores.Sort((a, b) => b.CompareTo(a)); // Sort the high scores in descending order

            while (highScores.Count > numberOfHighScoresToShow) // Remove excess high scores beyond the specified limit
            {
                highScores.RemoveAt(highScores.Count - 1);
            }
            SaveHighScores(); // Save the updated high scores to the file
            UpdateHighScoreText(); // Update the high score text in the UI
        }

    }

    void UpdateHighScoreText()
    {
        string highScoresText = "\n";
        for (int i = 0; i < highScores.Count; i++) // Iterate through the high scores list and format the text
        {
            highScoresText += $"{i + 1}. {highScores[i].ToString("F1")}M\n";
        }
        highScoreText.text = highScoresText; // Set the formatted text to the high score text UI element
    }

    void SaveHighScores()
    {
        // Create a HighScoreData object with the highest score
        HighScoreData highScoreData = new HighScoreData { HighScore = highScores[0] };
        // Convert the object to a JSON-formatted string
        string json = JsonUtility.ToJson(highScoreData);
        // Write the JSON string to the specified file path
        System.IO.File.WriteAllText(highScoreFilePath, json);
    }

    void LoadHighScore()
    {
        // Check if the high score file exists
        if (System.IO.File.Exists(highScoreFilePath))
        {
            // Read the JSON string from the file
            string json = System.IO.File.ReadAllText(highScoreFilePath);
            HighScoreData highScoreData = JsonUtility.FromJson<HighScoreData>(json);
            highScore = highScoreData.HighScore; // Update the current high score with the loaded value
            UpdateHighScoreText();// Update the high score text in the UI
        }
    }
}
