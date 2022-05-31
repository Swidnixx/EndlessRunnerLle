using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple GameManagers in the Scene!");
        }
    }

    //Gameplay
    public float worldScrollingSpeed = 0.1f;
    float score = 0;
    int coins = 0;
    int highscore;

    //UI
    public Text scoreText;
    public GameObject endGamePanel;
    public Text coinsText;
    public Text highscoreText;

    //Powerups
    public Battery battery;

    private void Start()
    {
        battery.isActive = false;

        coins = PlayerPrefs.GetInt("Coins", 0);
        coinsText.text = coins.ToString();

        highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = highscore.ToString();
    }

    private void FixedUpdate()
    {
        score += worldScrollingSpeed;
        scoreText.text = score.ToString("0");

        if(score > highscore)
        {
            highscore = (int)score;
            PlayerPrefs.SetInt("Highscore", highscore);
            highscoreText.text = highscore.ToString();
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        endGamePanel.SetActive(true);
    }

    public void GameRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void CoinCollected()
    {
        coins++;
        coinsText.text = coins.ToString();
        PlayerPrefs.SetInt("Coins", coins);
    }

    public void BatteryCollected()
    {
        battery.isActive = true;
        worldScrollingSpeed += battery.speedBoost;

        Invoke("CancelBattery", battery.duration);
    }

    void CancelBattery()
    {
        worldScrollingSpeed -= battery.speedBoost;
        battery.isActive = false;
    }
}
