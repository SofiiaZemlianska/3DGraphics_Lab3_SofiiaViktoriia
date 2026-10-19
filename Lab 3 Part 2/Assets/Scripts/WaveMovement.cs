using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    public float horizontalSpeed = 3f;
    public float verticalSpeed = 0.5f; 
    private int direction = 1; 

    // Update is called once per frame
    void Update()
    {
        // Movement
        transform.Translate(new Vector3(direction * horizontalSpeed, -verticalSpeed, 0) * Time.deltaTime);
        float screenEdge = Camera.main.orthographicSize * Camera.main.aspect;

        // If they hit the wall, flip the horizontal dir
        if (transform.position.x >= screenEdge - 1f)
        {
            direction = -1;
        }
        else if (transform.position.x <= -screenEdge + 1f)
        {
            direction = 1;
        }

        if (transform.position.y < -8f)
        {
            Destroy(gameObject);
        }

    }

}
