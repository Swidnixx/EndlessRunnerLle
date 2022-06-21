using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PowerupManager powerupManager;

    public Text batteryInfo;
    public Button upgradeBatteryButton;

    public Text magnetInfo;
    public Button upgradeMagnetButton;

    int coins;
    public Text coinsText;

    public void UpgradeBattery()
    {
        if(coins  >= powerupManager.battery.upgradeCost)
        {
            coins -= powerupManager.battery.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            powerupManager.battery = powerupManager.battery.upgrade;
            DisplayBattery();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
    void DisplayBattery()
    {
        string info = "Lvl " + powerupManager.battery.level + "\n";
        if(powerupManager.battery.upgrade != null)
        {
            info += powerupManager.battery.upgradeCost + " coins to upgrade";
        }
        else
        {
            info += "max level";
            upgradeBatteryButton.interactable = false;
        }
        batteryInfo.text = info;

        coinsText.text = coins.ToString();
    }

    public void UpgradeMagnet()
    {
        if (coins >= powerupManager.magnet.upgradeCost)
        {
            coins -= powerupManager.magnet.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            powerupManager.magnet = powerupManager.magnet.upgrade;
            DisplayMagnet();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
    void DisplayMagnet()
    {
        string info = "Lvl " + powerupManager.magnet.level + "\n";
        if (powerupManager.magnet.upgrade != null)
        {
            info += powerupManager.magnet.upgradeCost + " coins to upgrade";
        }
        else
        {
            info += "max level";
            upgradeMagnetButton.interactable = false;
        }
        magnetInfo.text = info;

        coinsText.text = coins.ToString();
    }

    private void OnEnable()
    {
        coins = PlayerPrefs.GetInt("Coins");

        DisplayBattery();
    }


}
