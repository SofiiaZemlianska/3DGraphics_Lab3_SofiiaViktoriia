using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 2;

    public GameObject enemyBulletPrefab;
    public float minFireRate = 2f;
    public float maxFireRate = 5f; 
    private float nextFireTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNextFireTime();
    }

    // Update is called once per frame
    void Update()
    {
        // Randomly shoot downwards
        if (Time.time > nextFireTime)
        {
            if (enemyBulletPrefab != null)
            {
                Instantiate(enemyBulletPrefab, transform.position + Vector3.down * 1f, Quaternion.identity);
            }
            SetNextFireTime();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
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
