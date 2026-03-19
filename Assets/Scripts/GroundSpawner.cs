using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject obstaclePrefab;
    public Transform player;
    public float groundLength = 30f;

    private Vector3 nextSpawnPos;

    void Start()
    {
        nextSpawnPos = Vector3.zero;

        for (int i = 0; i < 5; i++)
        {
            SpawnGround();
        }
    }

    void Update()
    {
        if (player.position.z + (groundLength * 2) > nextSpawnPos.z)
        {
            SpawnGround();
        }
    }

    void SpawnGround()
    {
        GameObject newGround = Instantiate(groundPrefab, nextSpawnPos, Quaternion.identity);

        // 🔥 Spawn multiple obstacles randomly
        int obstacleCount = Random.Range(1, 4); // 1 to 3 obstacles per ground

        for (int i = 0; i < obstacleCount; i++)
        {
            int lane = Random.Range(0, 3); // 0 = left, 1 = middle, 2 = right

            float laneDistance = 4f; // same as your PlayerController
            float xPos = 0;

            if (lane == 0) xPos = -laneDistance;
            else if (lane == 1) xPos = 0;
            else if (lane == 2) xPos = laneDistance;

            // random Z position on this ground piece
            float zOffset = Random.Range(5f, groundLength - 5f);

            Vector3 obstaclePos = new Vector3(
                xPos,
                1f,
                nextSpawnPos.z + zOffset
            );

            Instantiate(obstaclePrefab, obstaclePos, Quaternion.identity);
        }

        nextSpawnPos.z += groundLength;
    }
}