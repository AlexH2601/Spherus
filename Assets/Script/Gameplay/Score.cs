using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Alex Huang

public class Score : MonoBehaviour
{
    GameObject ball;
    Main ballMovement;
    int scoreThreshold;
    float speedMultiplier;
    bool thresholdReached;

    void Start()
    {
        ball = GameObject.Find("Ball");
        ballMovement = ball.GetComponent<Main>();
        scoreThreshold = 10; // Increments at which game speed increases
        speedMultiplier = 1f;
        thresholdReached = false; // Tracks whether the player has passsed the current obstacle
    }

    void Update()
    {
        int score = ScoreDisplay.scoreValue;
        // CHECKS IF THE PLAYER'S SCORE IS A MULTIPLE OF 10 AND THAT THE CODE IS RAN ONLY ONCE
        if (score != 0 && (score % scoreThreshold == 0) && !thresholdReached)
        {
            // INCREASES QUAD/OBSTACLE MOVEMENT
            thresholdReached = true;
            speedMultiplier += 0.2f;
            ballMovement.setSpeedMultiplier(speedMultiplier);
        }
        else if (score % scoreThreshold != 0)
        {
            thresholdReached = false;
        }

        Debug.Log("Speed Multiplier: " + speedMultiplier);
    }

    public void increaseScore(int increment)
    {
        // INCREMENTS GLOBAL SCORE VARIABLE
        ScoreDisplay.scoreValue += increment;
    }

    public float getSpeedMultiplier()
    {
        return speedMultiplier;
    }
}