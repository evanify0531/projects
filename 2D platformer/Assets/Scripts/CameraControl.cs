using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public Transform playerTransform;
    private float xleftBound = -19.0f;
    private float xrightBound = 20.43f;
    private float xPos;
    public float smoothSpeed = 0.125f;

    void Start()
    {
        playerTransform = player.transform;
    }

    
    void LateUpdate()
    {
        xPos = playerTransform.position.x;

        if (xPos < 0)
        {
            Vector3 desiredPosition = new Vector3(Mathf.Max(xleftBound, xPos), 0.3f, -10f);
            Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, desiredPosition, smoothSpeed);
            this.transform.position = smoothedPosition;
        }
        else if (xPos > 0)
        {
            Vector3 desiredPosition = new Vector3(Mathf.Min(xrightBound, xPos), 0.3f, -10f);
            Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, desiredPosition, smoothSpeed);
            this.transform.position = smoothedPosition;
        }
    }
}
