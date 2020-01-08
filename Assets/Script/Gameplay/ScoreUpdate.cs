using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    GameObject ball;
    CircleCollider2D ballCollider;
    Score score;
    BoxCollider2D scoreThreshold;
    bool scored;

    void Start()
    {
        ball = GameObject.Find("Ball");
        ballCollider = ball.GetComponent<CircleCollider2D>();
        score = ball.GetComponent<Score>();
        scoreThreshold = GetComponent<BoxCollider2D>();
        scored = false;
    }

    void Update()
    {
        // CHECKS IF THE PLAYER PASSES AN OBSTACLE
        if (scoreThreshold.IsTouching(ballCollider) && !scored)
        {
            score.increaseScore(1);
            scored = true;
        }
    }

    public void resetScored()
    {
        scored = false;
    }
}