using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public GameObject waveContainerPrefab;
    public GameObject enemyWave2Prefab;
    public GameObject enemyWave3Prefab;

    public GameObject powerUpPrefab;

    public float spawnInterval = 15.0f;
    public float waveDuration = 30f;


    // Wave 1 variables 
    public float wave1SpawnInterval = 12.0f;
    public float wave1Duration = 60f;

    private float wave1Timer = 0f;
    private float wave1SpawnTimer = 0f;
    private bool isWave1Active = false;

    // Wave 2 variables 
    public float wave2SpawnInterval = 15.0f;
    public float wave2Duration = 60f;
    private float wave2Timer = 0f;
    private float wave2SpawnTimer = 0f;
    private bool isWave2Active = false;

    // Wave 3 variables 
    public float wave3SpawnInterval = 25.0f;
    public float wave3Duration = 60f;
    private float wave3Timer = 0f;
    private float wave3SpawnTimer = 0f;
    private bool isWave3Active = false;

    void Start()
    {
        StartCoroutine(PowerUpRoutine());
    }

    IEnumerator PowerUpRoutine()
    {
        while (true)
        {
            // Wait for random duration between 25 and 45 seconds
            yield return new WaitForSeconds(Random.Range(25f, 45f));

            if (powerUpPrefab != null)
            {
                // Calculate screen boundaries so powerup doesn't spawn outside the screen
                float screenEdge = Camera.main.orthographicSize * Camera.main.aspect;
                float randomX = Random.Range(-screenEdge + 2f, screenEdge - 2f);

                // Create powerup at a random location at the top
                Vector3 spawnPos = new Vector3(randomX, 9f, 0);
                Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);

                Debug.Log("PowerUp dropped");
            }
        }
    }

    public void StartWave1()
    {
        Debug.Log("Wave 1 Spawning");
        isWave1Active = true;
        wave1Timer = 0f;
        wave1SpawnTimer = 0f;

        // Spawn the first group immediately
        SpawnWave1Group();
    }

    public void StartWave2()
    {
        Debug.Log("Wave 2 Spawning Started");
        isWave2Active = true;
        wave2Timer = 0f;
        wave2SpawnTimer = 0f;
        SpawnWave2Group();
    }

    public void StartWave3()
    {
        Debug.Log("Wave 3 Spawning Started");
        isWave3Active = true;
        wave3Timer = 0f;
        wave3SpawnTimer = 0f;
        SpawnWave3Group();
    }

    void Update()
    {
        // Check if Wave 1 is currently active
        if (isWave1Active)
        {
            wave1Timer += Time.deltaTime;
            wave1SpawnTimer += Time.deltaTime;

            // Stop spawning after 60 seconds
            if (wave1Timer >= wave1Duration)
            {
                isWave1Active = false;
            }
            // Spawn a new group every 12 seconds
            else if (wave1SpawnTimer >= wave1SpawnInterval)
            {
                wave1SpawnTimer = 0f;
                SpawnWave1Group();
            }
        }

        // Check if Wave 2 is currently active
        if (isWave2Active)
        {
            wave2Timer += Time.deltaTime;
            wave2SpawnTimer += Time.deltaTime;

            // Check if total duration of Wave 2 is done to stop spawning enemies
            if (wave2Timer >= wave2Duration)
            {
                isWave2Active = false;
            }
            // If wave is still active, check if we can spawn next group of enemies
            else if (wave2SpawnTimer >= wave2SpawnInterval)
            {
                wave2SpawnTimer = 0f;
                SpawnWave2Group();
            }
        }

        // Check if Wave 3 is currently active
        if (isWave3Active)
        {
            wave3Timer += Time.deltaTime;
            wave3SpawnTimer += Time.deltaTime;

            // Check if total duration of Wave 2 is done to stop spawning enemies
            if (wave3Timer >= wave3Duration)
            {
                isWave3Active = false;
            }
            // If wave is still active, check if we can spawn a new enemy
            else if (wave3SpawnTimer >= wave3SpawnInterval)
            {
                wave3SpawnTimer = 0f;
                SpawnWave3Group();
            }
        }
    }

    void SpawnWave1Group()
    {
        Vector3 spawnPos = new Vector3(0, 9, 0);
        Instantiate(waveContainerPrefab, spawnPos, Quaternion.identity);
        Debug.Log("Spawned a new Wave 1 block!");
    }

    void SpawnWave2Group()
    {
        int count = 5;
        float spacing = 4.5f;
        float startX = -(count - 1) * spacing / 2f;

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(startX + i * spacing, 6f, 0);
            Instantiate(enemyWave2Prefab, pos, Quaternion.identity);
        }
    }

    void SpawnWave3Group()
    {
        Vector3 spawnPos = new Vector3(0, 6f, 0);
        Instantiate(enemyWave3Prefab, spawnPos, Quaternion.identity);
    }
}