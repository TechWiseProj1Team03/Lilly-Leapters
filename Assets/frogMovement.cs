using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    //  Reference to animator component on the frog
    public Animator animator;
    private Rigidbody2D rb2D;

    public float speed = 2f;
    public float jumpForce = 5f;

    
    public bool isGrounded;
    public LayerMask whatIsGround;
    public Transform groundCheck; 
    public float checkRadius = 0.2f; 

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        MoveHorizontal();
        //  Stop jump animation once frog is grounded again
        animator.SetBool("isJumping", false);
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        Debug.Log(isGrounded);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void MoveHorizontal()
    {
        float h = Input.GetAxis("Horizontal");

        //  Determine the speed of the frog, if it's above 0.01 we play the movement animation
        animator.SetFloat("isMoving", Mathf.Abs(h));
        
        Vector2 position = transform.position;
        position.x += speed * h * Time.deltaTime;
        transform.position = position;
    }

    void Jump()
    {
        //  Frog is jumping so play jump animation 
        animator.SetBool("isJumping", true);
        rb2D.velocity = Vector2.up * jumpForce;
    }
}
