using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour, IFrogMovement 
{
    //  Reference to animator component on the frog
    public Animator animator;
    private Rigidbody2D rb2D;

    //  List of sounds that the frog can make 
    public List<AudioClip> sounds;

    public float speed = 2f;
    public float jumpForce = 10f;

    //  Determines which direction the sprite is facing 
    public bool isFacingLeft = false; 
    
    public bool isGrounded;
    public LayerMask whatIsGround;
    public float raycastDistance = 0.02f; 

    private int jumpCount = 0;
    private int maxJumps = 1;  // Single jump by default



    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
    }
    
    void Update()
    {
        MoveHorizontal();
        //  Stop jump animation once frog is grounded again
        animator.SetBool("isJumping", false);
        
        Vector2 raycastOrigin = new Vector2(transform.position.x, transform.position.y + 0.02f);
        isGrounded = Physics2D.Raycast(raycastOrigin, Vector2.down, raycastDistance, whatIsGround);

        Debug.DrawRay(transform.position, Vector2.down * raycastDistance, Color.black);  // Optional visualization
        

        Debug.Log(isGrounded);
        if (isGrounded)
        {
            jumpCount = 0;  // Reset jump count when grounded
        }
        
        // Check for jump key press and ensure jump count is below max allowed jumps
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumps)
        {
            Jump();
            jumpCount++;  // Increment jump count
        }
    }

    void MoveHorizontal()
    {
        float h = Input.GetAxis("Horizontal");

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

        //  Quick and dirty, will make more dynamic later
        AudioMgr.instance.PlaySound(sounds[1]);
    }

    //  Changes frog's direction to the opposite that it's currently facing 
    void flip() 
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        AudioMgr.instance.PlaySound(sounds[0]);
    }
    public void ActivateFlyPowerUp()
    {
        maxJumps = 2;  // Allow double jump
    }
}