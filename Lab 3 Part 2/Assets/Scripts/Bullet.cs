using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Destroy the bullet after 3 seconds
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime)
    }
    void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Enemy"))
        //{
        //    other.GetComponent<Enemy>().TakeDamage(1);
        //    Destroy(gameObject);
        //}
    }
}
