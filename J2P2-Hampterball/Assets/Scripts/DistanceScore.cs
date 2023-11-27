using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DistanceScore : MonoBehaviour
{
    [SerializeField] public Transform point;
    [SerializeField] public TMP_Text distanceText;

    float distance;
    int coins = 0;

    void Update()
    {
        distance = (point.transform.position - transform.position).magnitude;
        distanceText.text = distance.ToString("F1") + "M" + "\nCoins: " + coins;

        // Voeg punten toe na elke 10 meter
        if (distance >= (coins + 1) * 10)
        {
            coins++;
        }

    }
}
