using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public Text coinText;
    public Text highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = $"Highscore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
    // Update is called once per frame
    void Update()
    {
        coinText.text = "Score = " + coinCount.ToString();
       
    }
}
