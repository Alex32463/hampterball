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
    [SerializeField] private int numberOfHighScoresToShow = 5; // Aantal hoogste scores om weer te geven

    private List<float> highScores = new List<float>();
    public float distance;

    void Start()
    {
        // Laad de hoogste score bij het starten van het spel
        LoadHighScore();
        UpdateHighScoreText();
    }

    void Update()
    {
        distance = (point.transform.position - transform.position).magnitude;
        distanceText.text = distance.ToString("F1") + "M";

        if (distance > 0 && !highScores.Contains(distance))
        {
            highScores.Add(distance);
            highScores.Sort((a, b) => b.CompareTo(a));

            while (highScores.Count > numberOfHighScoresToShow)
            {
                highScores.RemoveAt(highScores.Count - 1);
            }
            SaveHighScores();
            UpdateHighScoreText();
        }

    }

    void UpdateHighScoreText()
    {
        string highScoresText = "\n";
        for (int i = 0; i < highScores.Count; i++)
        {
            highScoresText += $"{i + 1}. {highScores[i].ToString("F1")}M\n";
        }
        highScoreText.text = highScoresText;
    }

    void SaveHighScores()
    {
        // Sla de hoogste score op in een JSON-bestand
        HighScoreData highScoreData = new HighScoreData { HighScore = highScores[0] };
        string json = JsonUtility.ToJson(highScoreData);
        System.IO.File.WriteAllText(highScoreFilePath, json);
    }

    void LoadHighScore()
    {
        // Laad de hoogste score uit het JSON-bestand
        if (System.IO.File.Exists(highScoreFilePath))
        {
            string json = System.IO.File.ReadAllText(highScoreFilePath);
            HighScoreData highScoreData = JsonUtility.FromJson<HighScoreData>(json);
            highScore = highScoreData.HighScore;
            UpdateHighScoreText();
        }
    }
}
