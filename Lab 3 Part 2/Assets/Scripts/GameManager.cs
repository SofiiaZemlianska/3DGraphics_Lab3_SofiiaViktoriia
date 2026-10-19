using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private UIManager uiManager;

    public int lives = 3;
    public int score = 0;

    public AudioClip loseLifeSound;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        uiManager = FindFirstObjectByType<UIManager>();

        // Update text at the start
        if (uiManager != null)
        {
            uiManager.UpdateLives(lives);
            uiManager.UpdateScore(score);
        }

        StartCoroutine(WaitForWinRoutine());
    }

    public void AddScore(int points)
    {
        score += points;

        // Update text on the screen
        if (uiManager != null) uiManager.UpdateScore(score);

        Debug.Log("Score is now: " + score);
    }

    public void LoseLife()
    {
        lives--;

        // Play sound
        if (loseLifeSound != null)
        {
            AudioSource.PlayClipAtPoint(loseLifeSound, Camera.main.transform.position);
        }

        // Update text
        if (uiManager != null) uiManager.UpdateLives(lives);

        if (lives <= 0)
        {
            EndGame(false);
        }

    }

    private void EndGame(bool isWin)
    {
        PlayerController player = FindFirstObjectByType<PlayerController>();
        int collectedPowerUps = 0;

        if (player != null)
        {
            collectedPowerUps = player.powerUpsCollected;
        }

        if (uiManager != null)
        {
            uiManager.ShowEndScreen(isWin, score, collectedPowerUps, lives);
        }

        // Stop game
        Time.timeScale = 0f;
    }

    IEnumerator WaitForWinRoutine()
    {
        WaveSpawner spawner = FindFirstObjectByType<WaveSpawner>();
        if (spawner == null) yield break;

        // Calculate total game time (Wave 1, Wave 2, Wave 3, pauses and texts)
        float totalTime = spawner.wave1Duration + spawner.wave2Duration + spawner.wave3Duration + 10f;

        yield return new WaitForSeconds(totalTime);

        // If there are still lives left, it means player won
        if (lives > 0)
        {
            EndGame(true);
        }
    }

}
