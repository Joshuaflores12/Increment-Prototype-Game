using System;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// This class manages the buttons in the UI, allowing for easy access and control over their states and interactions.
public class ButtonManager : MonoBehaviour
{
    [Header("UI")]
    public Button[] buttons;
    public CoinData coinData;

    public void AddCoins() // Linear Coin Gain 
    {
        coinData.coinValue += 1;
        coinData.coinTracker.text = "Coins: " + coinData.coinValue.ToString();
    }

    public void upgradeLevel() 
    {
        coinData.Upgrade();
    }
}



