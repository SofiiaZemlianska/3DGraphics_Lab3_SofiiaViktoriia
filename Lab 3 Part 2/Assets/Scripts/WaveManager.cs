using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    public GameObject waveText;
    public GameObject enemyContainer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (waveText != null)
        {
            waveText.SetActive(true);
        }

        if (enemyContainer != null)
        {
            enemyContainer.SetActive(false);
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

        if (enemyContainer != null)
        {
            enemyContainer.SetActive(true);
        }
    }
}
