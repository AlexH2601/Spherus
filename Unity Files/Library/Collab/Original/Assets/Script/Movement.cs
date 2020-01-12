using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    int screen_width;
    Rigidbody2D player;
    SpriteRenderer sprite;
    Animator animator;
    Vector2 directionedMovement;
    Vector2 userInput;
    bool heldDirection;
    bool inAir;

    void Start()
    {
        screen_width = Screen.width;
        player = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        userInput = new Vector2(0f, 0f);
        heldDirection = true;
        inAir = false;
    }

    void Update()
    {
        //BASIC HORIZONTAL & VERTICAL MOVEMENT
        Vector2 userInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        directionedMovement = userInput.normalized * 0.5f;

        if ((userInput.x > 0) && (heldDirection = true))
        {
            sprite.flipX = true;
            heldDirection = false;
        }
        else if ((userInput.x < 0) && (!heldDirection))
        {
            sprite.flipX = false;
            heldDirection = true;
        }

        float multiplier = 0f;

        if (sprite.transform.position.y > -46)
        {
            multiplier = -1f;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("left shift");
              multiplier = 20f;
            }
        }

        directionedMovement.y = multiplier;
        Debug.Log("Y: " + directionedMovement.y);
        Debug.Log("X: " + directionedMovement.x);
        animator.SetFloat("xSpeed", Mathf.Abs(directionedMovement.x));

        if (Input.GetKeyDown("space"))
        {
            directionedMovement.y = 30f;
        }
    }

    void FixedUpdate()
    {
        player.MovePosition(player.position + directionedMovement);
    }
}