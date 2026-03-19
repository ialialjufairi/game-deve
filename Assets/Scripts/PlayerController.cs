using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneDistance = 4f;
    public float jumpForce = 8f;

    private int lane = 1; // 0 = left, 1 = middle, 2 = right
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // LEFT / RIGHT INPUT
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lane = Mathf.Max(0, lane - 1);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lane = Mathf.Min(2, lane + 1);
        }

        // Calculate target X
        float targetX = 0;
        if (lane == 0) targetX = -laneDistance;
        else if (lane == 2) targetX = laneDistance;

        // Maintain current Y & Z
        Vector3 targetPos = new Vector3(targetX, rb.position.y, rb.position.z);

        // Snap to lane
        rb.MovePosition(targetPos + Vector3.forward * forwardSpeed * Time.deltaTime);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}