using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    public GameObject waveText;
    public WaveSpawner spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (waveText != null)
        {
            waveText.SetActive(true);
        }

        StartCoroutine(StartWaveRoutine());
    }

    IEnumerator StartWaveRoutine()
    {
        yield return new WaitForSeconds(3f);

        if (waveText != null)
        {
            waveText.SetActive(false);
        }

        // Tell the spawner to start
        if (spawner != null)
        {
            spawner.StartSpawning();
        }
    }
}
