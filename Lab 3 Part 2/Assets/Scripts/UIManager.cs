using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject powerUpText;

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
}
