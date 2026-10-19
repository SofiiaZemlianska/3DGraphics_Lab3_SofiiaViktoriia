using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float fallSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        // Powerup descends
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // If powerup moved outside the screen, remove it
        if (transform.position.y < -8f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if powerup collides with player
        if (other.CompareTag("Player"))
        {
            Debug.Log("PowerUp collected!");

            Destroy(gameObject);
        }
    }

}
