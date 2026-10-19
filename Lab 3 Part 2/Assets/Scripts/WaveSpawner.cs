using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public GameObject waveContainerPrefab;
    public GameObject enemyWave2Prefab;
    public float spawnInterval = 10.0f;
    public float waveDuration = 30f;

    public void StartWave1()
    {
        Debug.Log("Wave 1 Spawning");
        Vector3 spawnPos = new Vector3(0, 9, 0);
        Instantiate(waveContainerPrefab, spawnPos, Quaternion.identity);
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
}