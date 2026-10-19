using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject powerUpText;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI powerUpsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (powerUpText != null) powerUpText.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    public void ShowPowerUpText()
    {
        if (powerUpText != null) powerUpText.SetActive(true);
    }

    public void HidePowerUpText()
    {
        if (powerUpText != null) powerUpText.SetActive(false);
    }

    public void UpdateLives(int lives)
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void ShowGameOver(int finalScore, int powerUps)
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            if (scoreText != null) scoreText.gameObject.SetActive(false);
            if (livesText != null) livesText.gameObject.SetActive(false);
            if (powerUpText != null) powerUpText.SetActive(false);

            if (finalScoreText != null)
                finalScoreText.text = "Final score: " + finalScore;

            if (powerUpsText != null)
                powerUpsText.text = "Powerups collected: " + powerUps;
        }
    }
}
