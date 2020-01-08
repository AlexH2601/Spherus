using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    GameObject ball;
    Movement ballMovement;
    int score;
    int scoreThreshold;
    float speedMultiplier;
    bool thresholdReached;

    void Start()
    {
        ball = GameObject.Find("Ball");
        ballMovement = ball.GetComponent<Movement>();
        score = 0;
        scoreThreshold = 10;
        speedMultiplier = 1f;
        thresholdReached = false;
    }

    void Update()
    {
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

        Debug.Log("Score: " + (score));
        Debug.Log("Speed Multiplier: " + speedMultiplier);
    }

    public void increaseScore(int increment)
    {
        score += increment;
    }

    public float getSpeedMultiplier()
    {
        return speedMultiplier;
    }
}