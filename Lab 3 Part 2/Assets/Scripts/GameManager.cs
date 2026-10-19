using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 3;
    public int score = 0;

    void Awake()
    {
        Instance = this;
    }
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score is now: " + score);
    }

    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            Debug.Log("Game Over!");

            Time.timeScale = 0f;
        }

    }

}
