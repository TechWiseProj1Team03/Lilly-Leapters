using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement2 : MonoBehaviour
{

    //  Reference to animator component on the frog
    public Animator animator;
    private Rigidbody2D rb2D;

    public float speed = 2f;
    public float jumpForce = 5f;

    //  Determines which direction the sprite is facing 
    public bool isFacingLeft = false; 
    
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
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    void MoveHorizontal()
    {
        float h = 0;

        if (Input.GetKey(KeyCode.A))
        {
            h = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            h = 1;
        }

        //  If our direction of movement is postive and we're facing left then we change rotation and set our toggle to false
        if (h > 0  && isFacingLeft) 
        {
            flip();
            isFacingLeft = false; 
        }
        //  If we're moving in the left direction and we're not facing left, flip the frog 
        else if (h < 0 && !isFacingLeft)
        {
            flip();
            isFacingLeft = true;
        }
        
        Vector2 position = transform.position;
        position.x += speed * h * Time.deltaTime;
        transform.position = position;

        //  Determine the speed of the frog, if it's above 0.01 we play the movement animation
        animator.SetFloat("isMoving", Mathf.Abs(h));
    }

    void Jump()
    {
        //  Frog is jumping so play jump animation 
        animator.SetBool("isJumping", true);
        rb2D.velocity = Vector2.up * jumpForce;
    }

    //  Changes frog's direction to the opposite that it's currently facing 
    void flip() 
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
