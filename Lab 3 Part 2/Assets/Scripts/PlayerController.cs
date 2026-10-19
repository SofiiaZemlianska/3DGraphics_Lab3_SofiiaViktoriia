using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;

    public GameObject bulletPrefab;
    public float normalFireRate = 0.3f;
    public float poweredUpFireRate = 0.15f;
    private float currentFireRate;
    private float nextFireTime = 0f;

    private InputSystem_Actions controls;

    public bool isInvulnerable = false;

    public bool isPoweredUp = false;
    public float powerUpDuration = 10f;
    private float powerUpTimer = 0f;

    void Awake()
    {
        controls = new InputSystem_Actions();
        currentFireRate = normalFireRate;
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

        // Check if powerup is active
        if (isPoweredUp)
        {
            powerUpTimer -= Time.deltaTime;
            // If time has run out, revert player's weapon back to normal
            if (powerUpTimer <= 0f)
            {
                DeactivatePowerUp();
            }
        }
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        if (bulletPrefab != null && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + currentFireRate;
            // Check if player has powerup
            if (isPoweredUp)
            {
                // Left bullet
                Instantiate(bulletPrefab, transform.position + Vector3.up * 1f + Vector3.left * 0.6f, Quaternion.identity);
                // Right bullet
                Instantiate(bulletPrefab, transform.position + Vector3.up * 1f + Vector3.right * 0.6f, Quaternion.identity);
            }
            else
            {
                // Normal fire rate
                Instantiate(bulletPrefab, transform.position + Vector3.up * 1f, Quaternion.identity);
            }
        }
    }

    public void ActivatePowerUp()
    {
        isPoweredUp = true;
        powerUpTimer = powerUpDuration;
        // Speed up shooting
        currentFireRate = poweredUpFireRate;

        Debug.Log("Weapon upgraded");
    }

    private void DeactivatePowerUp()
    {
        isPoweredUp = false;
        // Restore normal shooting
        currentFireRate = normalFireRate;

        Debug.Log("Weapon upgrade finished");
    }

    public void TakeDamage(int damageAmount = 1)
    {
        if (isInvulnerable) return;

        if (GameManager.Instance != null)
        {
            for (int i = 0; i < damageAmount; i++)
            {
                GameManager.Instance.LoseLife();
            }
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
