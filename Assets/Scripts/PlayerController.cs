using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    enum Direction
    {
        Down,
        Up,
        Left,
        Right
    }

    //animation
    private Animator animator;
    private string currentAnimation;
    private const string IDLE = "Oli_idle";
    private const string RUN_LEFT = "Oli_run_left";
    private const string RUN_RIGHT = "Oli_run_rigth";
    private const string RUN_UP = "Oli_run_up";
    private const string RUN_DOWN = "Oli_run_down";

    //player stats
    private float moveVertical;
    private float moveHorizontal;
    private float moveSpeed = 5f;
    private float maxHealth = 100f;
    private float currentHealth;
    private float baseDamage = 20f;
    private Vector2 moveVelocity;
    private bool canMove = true;



    // Start is called before the first frame update
    void Start()
    {
        rb2D= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", moveHorizontal);
        animator.SetFloat("Vertical", moveVertical);
        animator.SetFloat("Speed", moveVelocity.sqrMagnitude);


        moveVelocity = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;
    }

    private void FixedUpdate()
    {
        Move();
        Attack();
    }


    private void Move()
    {
        if (moveHorizontal != 0 || moveVertical != 0)
        {

            rb2D.velocity = moveVelocity;

        }
        else
        {
            moveVelocity = Vector2.zero;
            rb2D.velocity = moveVelocity;
            
        }
    }

    private void Attack()
    {
        
    }

    private void SwitchAnimation(string newState) { 
    
        if (newState == currentAnimation) { return; }

        animator.Play(newState);
        
        currentAnimation = newState;    
    }


}
