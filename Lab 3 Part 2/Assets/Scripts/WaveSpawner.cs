using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public GameObject waveContainerPrefab;
    public GameObject enemyWave2Prefab;
    public GameObject enemyWave3Prefab;

    public float spawnInterval = 15.0f;
    public float waveDuration = 30f;


    // Wave 1 variables 
    public float wave1SpawnInterval = 12.0f;
    public float wave1Duration = 60f;

    private float wave1Timer = 0f;
    private float wave1SpawnTimer = 0f;
    private bool isWave1Active = false;


    public void StartWave1()
    {
        Debug.Log("Wave 1 Spawning");
        isWave1Active = true;
        wave1Timer = 0f;
        wave1SpawnTimer = 0f;

        // Spawn the first group immediately
        SpawnWave1Group();
    }

    void Update()
    {
        // Only run if your Wave 1 is active
        if (!isWave1Active) return;

        wave1Timer += Time.deltaTime;
        wave1SpawnTimer += Time.deltaTime;

        // Stop spawning after 60 seconds
        if (wave1Timer >= wave1Duration)
        {
            isWave1Active = false;
            return;
        }

        // Spawn a new group every 12 seconds
        if (wave1SpawnTimer >= wave1SpawnInterval)
        {
            wave1SpawnTimer = 0f;
            SpawnWave1Group();
        }
    }

    void SpawnWave1Group()
    {
        Vector3 spawnPos = new Vector3(0, 9, 0);
        Instantiate(waveContainerPrefab, spawnPos, Quaternion.identity);
        Debug.Log("Spawned a new Wave 1 block!");
    }



    public void StartWave2()
    {
        Debug.Log("Wave 2 Spawning");
        int count = 5;
        float spacing = 4.5f;
        float startX = -(count - 1) * spacing / 2f;

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(startX + i * spacing, 6f, 0);
            Instantiate(enemyWave2Prefab, pos, Quaternion.identity);
        }
    }

    public void StartWave3()
    {
        Debug.Log("Wave 3 Spawning"); 
        Vector3 spawnPos = new Vector3(0, 6f, 0);
        Instantiate(enemyWave3Prefab, spawnPos, Quaternion.identity);
    }
}