using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public Transform playerTransform;
    private float xleftBound = -19.0f;
    private float xrightBound = 20.43f;
    private float xPos;


    void Start()
    {
        playerTransform = player.transform;
    }

    
    void Update()
    {
        xPos = playerTransform.position.x;

        if (xPos < 0)
        {
            this.transform.position = new Vector3(Mathf.Max(xleftBound, xPos), 0.3f, -10f);
        }
        else if (xPos > 0)
        {
            this.transform.position = new Vector3(Mathf.Min(xrightBound, xPos), 0.3f, -10f);
        }
    }
}
