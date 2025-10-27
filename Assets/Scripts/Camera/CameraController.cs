using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform Player;

    private float positionX = 6f;
    private float positionY = 0f;
    private float smoothSpeed = 0.05f;
    private float targetPositionX = 6f;

    private float Horizontal;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal > 0)
        {
            targetPositionX = 6f;
        }
        else if (Horizontal < 0)
        {
            targetPositionX = -6f;
        }

        positionX = Mathf.Lerp(positionX, targetPositionX, 0.01f);

        if (Player.position.y > positionY && Player.position.y >= 0)
        {
            positionY = Player.position.y;
        }

        positionY = Mathf.Max(positionY, 0f);

        Vector3 desiredPosition = new Vector3(Player.position.x + positionX, positionY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
