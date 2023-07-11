using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
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
        
        Vector2 position = transform.position;
        position.x += speed * h * Time.deltaTime;
        transform.position = position;
    }

    void Jump()
    {
        rb2D.velocity = Vector2.up * jumpForce;
        
    }
}
