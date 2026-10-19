using UnityEngine;

public class FreeMovement : MonoBehaviour
{
    public float speed = 4f;
    public float changeDirectionTime = 1.5f; // How often change direction

    private Vector3 targetPosition;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PickNewTarget();
    }

    // Update is called once per frame
    void Update()
    {
        // Fly to the target
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Timer to select a new target
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime || Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            PickNewTarget();
        }
    }

    void PickNewTarget()
    {
        timer = 0f;

        // Calculate screen boundaries
        float screenEdge = Camera.main.orthographicSize * Camera.main.aspect;
        float topEdge = Camera.main.orthographicSize - 1f;

        // Select a random point on the screen in the upper half, so that it doesn't fly toward player immediately
        float randomX = Random.Range(-screenEdge + 1f, screenEdge - 1f);
        float randomY = Random.Range(-3f, topEdge);

        targetPosition = new Vector3(randomX, randomY, 0f);
    }
}
