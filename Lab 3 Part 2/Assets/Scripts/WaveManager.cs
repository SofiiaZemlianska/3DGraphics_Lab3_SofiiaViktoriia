using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    public GameObject wave1Text;
    public GameObject wave2Text;
    public GameObject wave3Text;
    public WaveSpawner spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (wave1Text != null) wave1Text.SetActive(false);
        if (wave2Text != null) wave2Text.SetActive(false);
        if (wave3Text != null) wave3Text.SetActive(false);

        StartCoroutine(StartWaveRoutine());
    }

    IEnumerator StartWaveRoutine()
    {
        // Show WAVE 1 text for 2 seconds
        if (wave1Text != null) wave1Text.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (wave1Text != null) wave1Text.SetActive(false);

        // 1 second pause and then spawn enemies
        yield return new WaitForSeconds(1f);
        if (spawner != null) spawner.StartWave1();

        if (spawner != null) spawner.StartWave1();

        // Waiting while the first wave is on its way for 30 seconds
        yield return new WaitForSeconds(spawner.wave1Duration);

        // Show WAVE 2 text for 2 seconds
        if (wave2Text != null) wave2Text.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (wave2Text != null) wave2Text.SetActive(false);

        // 1 second pause and then spawn enemies
        yield return new WaitForSeconds(1f);
        if (spawner != null) spawner.StartWave2();

        // Waiting while the second wave is on its way for 30 seconds
        yield return new WaitForSeconds(spawner.waveDuration);

        // Show WAVE 3 text for 2 seconds
        if (wave3Text != null) wave3Text.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (wave3Text != null) wave3Text.SetActive(false);

        // 1 second pause and then spawn enemy
        yield return new WaitForSeconds(1f);
        if (spawner != null) spawner.StartWave3();
    }
}
