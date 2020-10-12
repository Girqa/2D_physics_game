using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public float speed = 20.0f;
    public float horizontalInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    public float jumpForce = 10.0f;

    public bool isGrounded;
    public Transform feetPos;
    public float cheackRadius = 0.3f;
    public LayerMask whatIsGround;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed , rb.velocity.y);
        if(facingRight == false && horizontalInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && horizontalInput < 0)
        {
            Flip();
        }
        if (horizontalInput == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, cheackRadius, whatIsGround);

        if (isGrounded == true && Input.GetAxis("Jump") != 0)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1f;
        transform.localScale = scaler;
    }
}
