using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Alex Huang

public class Obstacle_Controller : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        // CHECKS IF THE COLLISION IS WITH THE LEFT BOUND
        if (col.gameObject.tag == "Obstacles")
        {
            // SELECTS RANDOM Y COORDINATE TO RESET OBSTACLE TO
            float random = Random.Range(-32, 40);
            // RESETS POSITION OF OBSTACLE
            col.gameObject.transform.position = new Vector3(0f, random, 2f);
        }
        // MAKES THE OBSTACLE SCOREABLE AGAIN
        ScoreUpdate scoreUpdate = col.gameObject.GetComponentInChildren<ScoreUpdate>();
        scoreUpdate.resetScored();
    }
}