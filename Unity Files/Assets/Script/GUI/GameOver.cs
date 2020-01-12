using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Alex Huang

public class GameOver : MonoBehaviour
{
    HighScoreDisplay highScore;
    GameObject gameOver;

    void Start()
    {
        highScore = GetComponentInChildren<HighScoreDisplay>();
        gameOver = GameObject.Find("GameOver/Canvas");
        gameOver.SetActive(false);
    }

    public void end ()
    {
        // ENABLES GAME OVER SCREEN CANVAS
        gameOver.SetActive(true);
        bool newRecord = false;
        // CHECKS IF A NEW AND NON-ZERO HIGH SCORE HAS BEEN REACHED
        if (ScoreDisplay.scoreValue != 0 && HighScoreDisplay.highScoreValue < ScoreDisplay.scoreValue)
        {
            // UPDATES HIGH SCORE
            HighScoreDisplay.highScoreValue = ScoreDisplay.scoreValue;
            newRecord = true;
        }
        // DISPLAYS HIGH SCORE
        highScore.display(newRecord);
    }
}