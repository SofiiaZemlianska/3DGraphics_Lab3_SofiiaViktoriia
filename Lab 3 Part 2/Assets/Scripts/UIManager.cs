using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject powerUpText;

    public TextMeshPro livesText;
    public TextMeshPro scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (powerUpText != null) powerUpText.SetActive(false);
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
}
