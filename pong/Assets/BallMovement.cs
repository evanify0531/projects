using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed = 5f;
    Rigidbody2D rb;
    public float startDirX;
    public float startDirY;
    public float speedMultiplier = 1f;

    public int score1 = 0;
    public int score2 = 0;

    private bool collisionOnceChecker = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("BallStart", 2f);
    }


    void Update()
    {
        
    }

    private void BallReset()
    {
        BallToOrigin();
        ballSpeed = 5f;
        speedMultiplier = 1f;
        collisionOnceChecker = true;
        Invoke("BallStart", 1f);
    }

    void BallToOrigin()
    {
        rb.velocity = Vector2.zero;
        this.transform.position = new Vector3(0f, 0f, 0f);
    }

    void BallStart()
    {
        float randomNumberX = Random.Range(0, 2);
        float randomNumberY = Random.Range(0, 2);
        
        if (randomNumberX < 1)
        {
            startDirX = Random.Range(4, 10);
        }
        else if( randomNumberX > 0)
        {
            startDirX = Random.Range(-10, -4);
        }
        if (randomNumberY < 1)
        {
            startDirY = Random.Range(4, 10);
        }
        else if (randomNumberY > 0)
        {
            startDirY = Random.Range(-10, -4);
        }

        
        Vector2 startForce = new Vector2(startDirX, startDirY);
        startForce.Normalize();
        rb.velocity = startForce * ballSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player1") || collision.collider.CompareTag("Player2"))
        {
            Vector2 vel;
            vel.x = rb.velocity.x;
            vel.y = (rb.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y * 3);
            speedMultiplier += 1f;
            rb.AddForce(vel * speedMultiplier);
            //Debug.Log(ballSpeed);
            //Debug.Log(vel * ballSpeed);
            Debug.Log(speedMultiplier);
        }

        if(collision.collider.CompareTag("GoalpostLeft") && collisionOnceChecker)
        {
            rb.velocity = new Vector2(1f, 1f);
            Invoke("BallReset", 1f);
            score2++;
            collisionOnceChecker = false;
        }

        if (collision.collider.CompareTag("GoalpostRight") && collisionOnceChecker)
        {
            rb.velocity = new Vector2(1f, 1f);            
            Invoke("BallReset", 1f);
            score1++;
            collisionOnceChecker = false;
        }
    }
}
