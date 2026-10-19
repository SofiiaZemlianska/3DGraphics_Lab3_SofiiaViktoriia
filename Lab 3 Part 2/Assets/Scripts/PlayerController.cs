using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;

    public GameObject bulletPrefab;
    public float fireRate = 0.3f;
    private float nextFireTime = 0f;

    private InputSystem_Actions controls;

    public bool isInvulnerable = false;

    void Awake()
    {
        controls = new InputSystem_Actions();
    }

    void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Attack.performed += OnFire;
    }

    void OnDisable()
    {
        controls.Player.Attack.performed -= OnFire;
        controls.Player.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        // Movement
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        transform.Translate(Vector3.right * moveInput.x * speed * Time.deltaTime);

        //Calculate the exact screen edge based on the camera
        float screenEdge = Camera.main.orthographicSize * Camera.main.aspect;

        // Clamp to the screen edge
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -screenEdge, screenEdge);
        transform.position = clampedPos;
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        if (bulletPrefab != null && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Instantiate(bulletPrefab, transform.position + Vector3.up * 1f, Quaternion.identity);
        }
    }

    public void TakeDamage()
    {
        if (isInvulnerable) return;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoseLife();
        }

        if (GameManager.Instance != null && GameManager.Instance.lives <= 0)
        {
            Destroy(gameObject);
            return;
        }

        StartCoroutine(RespawnRoutine());
    }

    System.Collections.IEnumerator RespawnRoutine()
    {
        isInvulnerable = true;

        Renderer playerRenderer = GetComponent<Renderer>();

        // Flash for 2 seconds
        for (int i = 0; i < 20; i++)
        {
            if (playerRenderer != null)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
            }
            yield return new WaitForSeconds(0.1f);
        }

        if (playerRenderer != null)
        {
            playerRenderer.enabled = true; 
        }

        isInvulnerable = false; 
    }
}
