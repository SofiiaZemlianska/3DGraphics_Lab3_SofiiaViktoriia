using System.Drawing;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public float radius = 2f;
    public float angularSpeed = 90f;    // Degrees per second
    public float verticalSpeed = 0.3f;  // Slowly descends

    private Vector3 center;
    private float angle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        center = transform.position;
        // Random starting angle, so they don't all start from the same point
        angle = Random.Range(0f, 360f);
        // Shift them to this angle
        float rad = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f) * radius;
        transform.position = center + offset;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase angle over time based on angular speed to create circular motion
        angle += angularSpeed * Time.deltaTime;

        float rad = angle * Mathf.Deg2Rad;
        // Calculate offset from the center point
        Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f) * radius;

        // Move the center point of the circle slowly downwards over time
        center += Vector3.down * verticalSpeed * Time.deltaTime;
        transform.position = center + offset;

        // Check if enemy has gone below the bottom of the screen
        if (transform.position.y < -8f)
        {
            Destroy(gameObject);
        }
    }
}
