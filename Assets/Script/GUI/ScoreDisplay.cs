using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author: Alex Huang

public class ScoreDisplay : MonoBehaviour
{
    public static int scoreValue;
    Text score;

    void Start()
    {
        scoreValue = 0;
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = "Score: " + scoreValue;
    }
}