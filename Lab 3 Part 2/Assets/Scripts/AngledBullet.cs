using UnityEngine;

public class AngledBullet : MonoBehaviour
{
    public float speed = 7f;
    public float angleInDegrees = 0f; // 0 = straight down, 45 = down-left, -45 = down-right
    private Vector3 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Calculate the direction of movement based on an angle
        float rad = (angleInDegrees - 90f) * Mathf.Deg2Rad;
        moveDirection = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f);

        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(2);
            }
            Destroy(gameObject);
        }
    }
}
