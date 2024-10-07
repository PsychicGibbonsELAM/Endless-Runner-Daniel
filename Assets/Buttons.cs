using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Buttons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1.0f;
    }
    public void CreditsButt()
    {
        SceneManager.LoadSceneAsync(2);
        Time.timeScale = 1.0f;
    }
}
