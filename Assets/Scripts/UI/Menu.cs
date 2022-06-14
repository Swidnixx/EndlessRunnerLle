using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text highscoreText;
    public GameObject menuPanel;
    public GameObject shopPanel;

    private void Start()
    {
        BackToMenu();
    }

    public void GoToShop()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }
    public void BackToMenu()
    {
        menuPanel.SetActive(true);
        shopPanel.SetActive(false);
        
        highscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
