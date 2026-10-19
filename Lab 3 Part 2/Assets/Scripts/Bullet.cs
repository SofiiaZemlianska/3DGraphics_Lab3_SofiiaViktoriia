using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Destroy the bullet after 2 seconds
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        // If it hits an Enemy
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Bullet hit enemy!");

            Enemy enemyScript = other.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(1);
            }

            Destroy(gameObject);
        }
    }
}
