using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public GameObject deathScreenCanvas;

    public void ShowDeathScreen()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1.0f;
    }
    // Start is called before the first frame update
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}