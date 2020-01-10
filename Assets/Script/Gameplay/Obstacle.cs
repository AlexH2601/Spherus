using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Alex Huang

public class Obstacle : MonoBehaviour
{
    GameObject ball;
    Main ballMovement;
    CircleCollider2D ballCollider;
    Rigidbody2D obstacle;
    BoxCollider2D obstacleCollider;
    float speedMultiplier;
    bool hasStarted;
    bool hasEnded;
    bool gameOver;
    bool slowDown;

    void Start()
    {
        ball = GameObject.Find("Ball");
        ballMovement = ball.GetComponent<Main>();
        ballCollider = ball.GetComponent<CircleCollider2D>();
        obstacle = GetComponent<Rigidbody2D>();
        obstacleCollider = GetComponent<BoxCollider2D>();
        speedMultiplier = 1f;
        hasStarted = false;
        hasEnded = false;
        gameOver = false;
    }

    void Update()
    {
        // CHECKS IF THE GAME HAS STARTED
        if (!hasStarted)
        {
            // UPDATES hasStarted
            hasStarted = ballMovement.getHasStarted();
            return;
        }
        // UPDATES hasEnded
        hasEnded = ballMovement.getHasEnded();
        // CHECKS IF THE GAME IS OVER
        if (hasEnded)
        {
            if (!gameOver)
            {
                GameObject.Find("GameOver").GetComponent<GameOver>().end();
                gameOver = true;
            }
            return;
        }
        // UPDATES speedMultiplier
        speedMultiplier = ball.GetComponentInChildren<Score>().getSpeedMultiplier();
        // CHECKS IF THE PLAYER HAS ACTIVATED SLOW DOWN
        if (ballMovement.getSlowDown())
        {
            // MOVES THE OBSTACLES AT A SLOWER RATE
            obstacle.MovePosition(obstacle.position + new Vector2(-0.62f * speedMultiplier, 0f));
        }
        else
        {
            // MOVES THE OBSTACLES AT THE REGULAR RATE
            obstacle.MovePosition(obstacle.position + new Vector2(-1.27f * speedMultiplier, 0f));
        }
        // CHECKS IF THE PLAYER HAS COLLIDED WITH AN OBSTACLE
        if (obstacleCollider.IsTouching(ballCollider))
        {
            // UPDATES hasEnded
            hasEnded = true;
            // UPDATES hasEnded IN THE MOVEMENT CLASS OF THE BALL OBJECT
            ballMovement.setHasEnded();
            // REMOVES BALL FROM THE SCREEN
            ballMovement.removeBall();
        }
    }
}