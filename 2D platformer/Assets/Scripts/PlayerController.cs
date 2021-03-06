using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables for horizontal movement
    public float moveSpeed = 10.0f;
    private float moveDir;
    public Rigidbody2D rb;
    public Transform player;
    private bool facingRight = true;

    //variables related to jumping
    public float jumpForce;
    private bool isGrounded;
    public float checkRadius;
    public Transform feetPos;
    public LayerMask whatIsGround;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool isJumping;
    public float jumpingGravity = 5f;  

    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

 
    void Update()
    {
        moveDir = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(moveDir));
        anim.SetFloat("Y velocity", rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        anim.SetBool("Grounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.gravityScale = 1f;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = 5f; // This code is a bit weird. When I'm grounded, as directed in the FixedUpdate section, my gravity is 10.
            //However, the moment I press space while grounded, I give the character gravity 1. Then once the velocity is given, I set it to 5 to speed up the descent.
        }

        else if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }

            else if (jumpTimeCounter < 0)
            {
                isJumping = false;
            }
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }


 

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDir * moveSpeed, rb.velocity.y);

        if (moveDir < 0 && facingRight)
        {
            Flip();
        }

        else if (moveDir > 0 && !facingRight)
        {
            Flip();
        }

        if (isJumping)
        {
            //rb.gravityScale = jumpingGravity;
        }

        else if (isGrounded && rb.velocity.y == 0)
        {
            rb.gravityScale = 10f;
        }

     
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = player.localScale;
        theScale.x *= -1;
        player.localScale = theScale;
    }
}
