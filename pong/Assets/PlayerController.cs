using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float moveDir;
    private float topBound = 4f;
    private float botBound = -4f;
    private float posY;
    Transform player;

    void Start()
    {
        player = GetComponent<Transform>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveDir = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDir = -1f;
        }
        else
        {
            moveDir = 0f;
        }
        Vector3 moveVector = new Vector3(0f, moveDir * moveSpeed * Time.deltaTime, 0f);
        player.Translate(moveVector);

        posY = player.position.y;
        if (player.position.y > topBound)
        {
            posY = topBound;
        }

        else if (player.position.y < botBound)
        {
            posY = botBound;
        }
        player.position = new Vector2(-7f, posY);
    }
}
