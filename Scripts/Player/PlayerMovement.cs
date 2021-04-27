using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;

    public Rigidbody2D rb;

    private Vector3 movement;
    private Animator animator;

   

    private void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;

        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
 
    }
    void UpdateAnimationAndMove()
    {
        if (movement != Vector3.zero)
        {
            MoveCharacter();
            movement.x = Mathf.Round(movement.x);
            movement.y = Mathf.Round(movement.y);
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    void MoveCharacter()
    {
        movement.Normalize();
        rb.MovePosition(
            transform.position + movement * speed * Time.fixedDeltaTime
        );
     

    }
}
