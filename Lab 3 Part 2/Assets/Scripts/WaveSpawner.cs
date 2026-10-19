using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public GameObject waveContainerPrefab;
    public float spawnInterval = 10.0f;
    public float waveDuration = 30f;

    private float waveTimer = 0f;
    private float spawnTimer = 0f;
    private bool isWaveActive = false;

    public void StartSpawning()
    {
        isWaveActive = true;
        waveTimer = 0f;
        spawnTimer = 0f;

        // Spawn the first group immediately
        SpawnGroup();
    }

    void Update()
    {
        if (!isWaveActive) return;

        // Tick the timers
        waveTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        // Stop spawning after 30 seconds
        if (waveTimer >= waveDuration)
        {
            isWaveActive = false;
            Debug.Log("Wave 1 finished spawning!");
            return;
        }

        // Spawn a new group every 5 seconds
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnGroup();
        }
    }

    void SpawnGroup()
    {
        Vector3 spawnPos = new Vector3(0, 9, 0);

        Instantiate(waveContainerPrefab, spawnPos, Quaternion.identity);
    }
}