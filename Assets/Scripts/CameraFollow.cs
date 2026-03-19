using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;     // Player to follow
    public Vector3 offset;       // Offset from player

    void Start()
    {
        // Calculate initial offset if not set
        if (offset == Vector3.zero && player != null)
            offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player != null)
            transform.position = player.position + offset;
    }
}