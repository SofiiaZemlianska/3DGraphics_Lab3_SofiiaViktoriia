using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 2;
    public int pointsForHit = 50;
    public int pointsForKill = 100;
    public GameObject enemyBulletPrefab;
    public float minFireRate = 2f;
    public float maxFireRate = 5f; 
    private float nextFireTime;
    // Flag for a dangerous enemy that fires in a spread pattern
    public bool isDangerous = false;

    public AudioClip deathSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set random initial delay so enemies don't all shoot at the exact same frame
        nextFireTime = Time.time + Random.Range(0.5f, maxFireRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -8f)
        {
            Destroy(gameObject);
        }

        // Randomly shoot downwards
        if (Time.time > nextFireTime)
        {
            if (enemyBulletPrefab != null)
            {
                if (isDangerous)
                {
                    ShootSpread();
                }
                else
                {
                    // Normal shoot
                    Instantiate(enemyBulletPrefab, transform.position + Vector3.down * 1f, Quaternion.identity);
                }
            }
            SetNextFireTime();
        }
    }

    void ShootSpread()
    {
        // Fire three bullets: down-left, straight down and down-right.
        float[] angles = { 45f, 0f, -45f };

        foreach (float angle in angles)
        {
            // Create bullet
            GameObject bullet = Instantiate(enemyBulletPrefab, transform.position + Vector3.down * 1f, Quaternion.identity);

            // Give an angle
            AngledBullet angledScript = bullet.GetComponent<AngledBullet>();
            if (angledScript != null)
            {
                angledScript.angleInDegrees = angle;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        // Give points for every hit
        if (health > 0)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(pointsForHit);
            }
        }
        // If enemy dies, give bonus points
        else if (health <= 0)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(pointsForKill);
            }

            if (deathSound != null)
            {
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
            }

            Destroy(gameObject);
        }
    }

    void SetNextFireTime()
    {
        nextFireTime = Time.time + Random.Range(minFireRate, maxFireRate);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.TakeDamage();
            }
            Destroy(gameObject);
        }
    }
}
