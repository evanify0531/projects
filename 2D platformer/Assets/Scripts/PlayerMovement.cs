using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 10.0f;
    private float moveDir;
    public Rigidbody2D rb;
    public Transform player;
    private bool facingRight = true;

    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

 
    void Update()
    {
        moveDir = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(moveDir));
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

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = player.localScale;
        theScale.x *= -1;
        player.localScale = theScale;
    }


}
