using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject powerUpText;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    // Variables for gameover screen
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI gameOverPowerUpsText;

    // Variables for win screen
    public GameObject winPanel;
    public TextMeshProUGUI winScoreText;
    public TextMeshProUGUI winPowerUpsText;
    public TextMeshProUGUI winLivesText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (powerUpText != null) powerUpText.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);
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

    public void ShowEndScreen(bool isWin, int finalScore, int powerUps, int livesLeft)
    {
        // Hide old texts
        if (scoreText != null) scoreText.gameObject.SetActive(false);
        if (livesText != null) livesText.gameObject.SetActive(false);
        if (powerUpText != null) powerUpText.SetActive(false);

        // Check if player won or lose
        if (isWin)
        {
            if (winPanel != null)
            {
                winPanel.SetActive(true);
                if (winScoreText != null) winScoreText.text = "Final score: " + finalScore;
                if (winPowerUpsText != null) winPowerUpsText.text = "Powerups collected: " + powerUps;
                if (winLivesText != null) winLivesText.text = "Lives left: " + livesLeft;
            }
        }
        else
        {
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
                if (gameOverScoreText != null) gameOverScoreText.text = "Final score: " + finalScore;
                if (gameOverPowerUpsText != null) gameOverPowerUpsText.text = "Powerups collected: " + powerUps;
            }
        }
    }
}
