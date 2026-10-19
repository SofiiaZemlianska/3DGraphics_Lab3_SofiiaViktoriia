using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private UIManager uiManager;

    public int lives = 3;
    public int score = 0;

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

        // Update text
        if (uiManager != null) uiManager.UpdateLives(lives);

        if (lives <= 0)
        {
            Debug.Log("Game Over!");

            Time.timeScale = 0f;
        }

    }

}
