using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Battery battery;
    public Text batteryInfo;

    int coins;
    public Text coinsText;

    public void UpgradeBattery()
    {
        if(coins  >= battery.upgradeCost)
        {

        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
    void DisplayBattery()
    {
        string info = "Lvl " + battery.level + "\n";
        info += battery.upgradeCost + " coins to upgrade";
        batteryInfo.text = info;
    }

    private void OnEnable()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();

        DisplayBattery();
    }


}
