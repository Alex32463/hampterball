using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreScript : MonoBehaviour
{
    [SerializeField] private string highScoreFilePath = "highScore.json";
    private float highScore;
    [SerializeField] public Transform point;
    [SerializeField] public TMP_Text distanceText;
    [SerializeField] public TMP_Text highScoreText;


    public float distance;
    int coins = 0;

    void Start()
    {
        // Laad de hoogste score bij het starten van het spel
        LoadHighScore();
    }

    void Update()
    {
        // Je bestaande code blijft hier hetzelfde
        distance = (point.transform.position - transform.position).magnitude;
        distanceText.text = distance.ToString("F1") + "M" + "\nCoins: " + coins;

        // Voeg punten toe na elke 10 meter
        if (distance >= (coins + 1) * 10)
        {
            coins++;
        }
        // Controleer of de huidige score hoger is dan de hoogste score
        if (distance > highScore)
        {
            highScore = distance;

            // Update de tekst van de hoogste score
            UpdateHighScoreText();

            // Sla de hoogste score op
            SaveHighScore();
        }
    }

    void UpdateHighScoreText()
    {
        // Update de tekst van de hoogste score in je UI
        // Gebruik hiervoor distanceText of een andere tekstcomponent
        // Laat het in het door jou gewenste formaat zien
        highScoreText.text = highScore.ToString("F1") + "M";
    }

    void SaveHighScore()
    {
        // Sla de hoogste score op in een JSON-bestand
        HighScoreData highScoreData = new HighScoreData { HighScore = highScore };
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
