using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreBoardButton : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void ShowPanel()
    {
        panel.SetActive(true); // Set the panel to be active, making it visible
    }

    public void ClosePanel()
    {
        panel.SetActive(false); // Set the panel to be inactive, hiding it
    }
}
