using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Alex Huang

public class Main : MonoBehaviour
{
    Rigidbody2D player;
    SpriteRenderer sprite;
    Animator animator;
    Vector2 directionedMovement;
    Vector2 userInput;
    GameObject quad;
    ConstantScroll quadScript;
    GameObject ground;
    BoxCollider2D groundCollider;
    GameObject MovingParticlesLeft;
    SpriteRenderer particleSpriteLeft;
    Animator particleAnimationLeft;
    GameObject MovingParticlesRight;
    SpriteRenderer particleSpriteRight;
    Animator particleAnimationRight;
    bool hasStarted;
    bool hasEnded;
    bool slowDown;
    bool heldDirection;
    bool inAir;
    bool jump;
    bool right;
    bool left;
    int jumpCounter;
    float speedMultiplier;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<ContinuousAudio>().play();
        player = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        userInput = new Vector2(0f, 0f);
        quad = GameObject.Find("Quad");
        quadScript = quad.GetComponent<ConstantScroll>();
        ground = GameObject.Find("Barriers/Ground");
        groundCollider = ground.GetComponent<BoxCollider2D>();
        MovingParticlesLeft = GameObject.Find("Ball/MovingParticlesLeft");
        particleSpriteLeft = MovingParticlesLeft.GetComponent<SpriteRenderer>();
        particleSpriteLeft.enabled = false;
        particleAnimationLeft = MovingParticlesLeft.GetComponent<Animator>();
        MovingParticlesRight = GameObject.Find("Ball/MovingParticlesRight");
        particleSpriteRight = MovingParticlesRight.GetComponent<SpriteRenderer>();
        particleSpriteRight.enabled = false;
        particleAnimationRight = MovingParticlesRight.GetComponent<Animator>();
        heldDirection = true;
        jumpCounter = 0;
        speedMultiplier = 1f;
    }

    void Update()
    {
        // CHECKS IF THE GAME HAS ENDED
        if (hasEnded)
        {
            return;
        }

        // CHECKS IF THE PLAYER IS GROUNDED
        if (player.IsTouching(groundCollider))
        {
            inAir = false;
        }
        else
        {
            inAir = true;
        }

        //BASIC HORIZONTAL MOVEMENT INPUT
        Vector2 userInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        directionedMovement = userInput.normalized * 0.5f;

        // CHECKS IF THE GAME HAS STARTED
        if (!hasStarted)
        {
            // STARTS THE QUAD MOVEMENT WHEN THE GAME BEGINS
            if (directionedMovement.x != 0)
            {
                hasStarted = true;
                GameObject.Find("Tutorial").SetActive(false);
                quadScript.bgSpeed = 0.1f * speedMultiplier;
            }
            else
            {
                return;
            }  
        }

        // PLAYER ANIMATION CONTROL
        if ((userInput.x > 0) && (heldDirection = true))
        {
            sprite.flipX = true;
            particleSpriteLeft.enabled = true;
            particleSpriteRight.enabled = false;
            heldDirection = false;
        }
        else if ((userInput.x < 0) && (!heldDirection))
        {
            sprite.flipX = false;
            particleSpriteLeft.enabled = false;
            particleSpriteRight.enabled = true;
            heldDirection = true;
        }
        animator.SetFloat("xSpeed", Mathf.Abs(directionedMovement.x));

        // ADDITIONAL Y-AXIS GRAVITY FORCE
        float multiplier = 0f;
        if (inAir)
        {
            multiplier = -2f;
            // CHECKS IF THE PLAYER HAS ACTIVATED SLOW DOWN
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
            {
                // ADJUSTS QUAD MOVEMENT SPEED
                quadScript.bgSpeed = 0.05f * speedMultiplier;
                slowDown = true;
                // REDUCES PLAYER FALLING SPEED
                multiplier = -.75f;
            }
            else
            {
                // REGULAR QUAD MOVEMENT SPEED
                quadScript.bgSpeed = 0.1f * speedMultiplier;
                slowDown = false;
            }
        }
        else
        {
            // REGULAR QUAD MOVEMENT SPEED
            quadScript.bgSpeed = 0.1f * speedMultiplier;
            slowDown = false;
        }
        // ASSIGNS Y-AXIS FORCE
        directionedMovement.y = multiplier;

        // PLAYER MOVEMENT PARTICLE CONTROL
        if (directionedMovement.x == 0)
        {
            animator.enabled = false;
            if (sprite.flipX)
            {
                particleSpriteLeft.enabled = false;
            }
            else
            {
                particleSpriteRight.enabled = false;
            }
            if (!inAir) {
                // X-AXIS RESISTANCE FORCE
                directionedMovement.x = -1.25f * speedMultiplier;
            }
        }
        else
        {
            animator.enabled = true;
            if (inAir)
            {
                particleSpriteLeft.enabled = false;
                particleSpriteRight.enabled = false;
            }
            else if (sprite.flipX)
            {
                particleSpriteLeft.enabled = true;
            }
            else
            {
                particleSpriteRight.enabled = true;
                // X-AXIS RESISTANCE FORCE
                directionedMovement.x = -1.75f * speedMultiplier;
            }
        }

        // JUMP CONTROL
        if ((Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown("w") || Input.GetKeyDown("space")) && !inAir)
        {
            jump = true;
            // CHECKS WHAT DIRECTION PLAYER IS FACING IN AIR
            if (directionedMovement.x > 0)
            {
                right = true;
            }
            else if (directionedMovement.x < 0)
            {
                left = true;
            }
        }

        Debug.Log("X: " + directionedMovement.x);
        Debug.Log("Y: " + directionedMovement.y);
    }

    void FixedUpdate()
    {
        // DETERMINES IF PLAYER IS JUMPING OR MOVING
        if (jump)
        {
            jumpMove();
        }
        else if (!hasEnded)
        {
            player.MovePosition(player.position + directionedMovement);
        }
    }

    void jumpMove()
    {
        // JUMP CONTROLS MOVEMENT SCRIPT FOR 15 FRAMES
        if (jumpCounter == 15)
        {
            // RESETS JUMP PREFERENCES
            jump = false;
            right = false;
            left = false;
            jumpCounter = 0;
        }
        else
        {
            jumpCounter++;
            // ANGLED JUMPING AND NORMAL JUMPING
            if (right)
            {
                // ANGLED JUMPING TO THE RIGHT
                player.MovePosition(player.position + (new Vector2(1f, (15 - jumpCounter))));
            }
            else if (left)
            {
                // ANGLED JUMPING TO THE LEFT
                player.MovePosition(player.position + (new Vector2(-1f * speedMultiplier, (15 - jumpCounter))));
            }
            else
            {
                // NORMAL JUMPING
                player.MovePosition(player.position + (new Vector2(0f, (15 - jumpCounter))));
            }
        }
    }

    public bool getSlowDown()
    {
        return slowDown;
    }

    public bool getHasStarted()
    {
        return hasStarted;
    }

    public bool getHasEnded()
    {
        return hasEnded;
    }

    public void setHasEnded()
    {
        hasEnded = true;
        quadScript.bgSpeed = 0f;
    }

    public void setSpeedMultiplier(float speedMultiplier)
    {
        this.speedMultiplier = speedMultiplier;
    }

    public void removeBall()
    {
        // DISABLES BALL SPRITERENDERER AND MOVEMENT PARTICLES
        sprite.enabled = false;
        particleSpriteLeft.enabled = false;
        particleSpriteRight.enabled = false;
    }
}