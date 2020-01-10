using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author: Alex Huang

public class HighScoreDisplay : MonoBehaviour
{
    public static int highScoreValue = 0;
    Text score;
    newDisplay newIndicator;

    void Start()
    {
        score = GetComponent<Text>();
        newIndicator = GetComponentInChildren<newDisplay>();
    }

    public void display(bool newRecord)
    {
        // CHECKS IF A NEW RECORD HAS BEEN REACHED
        if (newRecord)
        {
            newIndicator.appear();
        }
        score.text = "High Score: " + highScoreValue;
    }
}