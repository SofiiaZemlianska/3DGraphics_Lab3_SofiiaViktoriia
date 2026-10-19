using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 3;

    void Awake()
    {
        Instance = this;
    }

    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            Debug.Log("Game Over!");
        }
    }

    public void TakeDamage()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoseLife();
        }

        if (GameManager.Instance != null && GameManager.Instance.lives <= 0)
        {
            Destroy(gameObject); 
        }
    }
}
