using UnityEngine;
using TMPro;
// This class represents the data associated with a coin in the game, such as its value, type, and any other relevant properties.
// this class also manages the formula for linear and exponential coin gain, allowing for easy adjustments to the coin generation mechanics as needed.
// this class also manages this upgrades costs to increase exponentially
// the passive coin gain from the upgrades and linear coin gain from time will be calculated via formulas.
public class CoinData : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI coinTracker;
    public TextMeshProUGUI coinGenerationTracker;
    public TextMeshProUGUI upgradeCostTracker;
    public TextMeshProUGUI upgradeLevelTracker;
    public TextMeshProUGUI status;

    [Header("Values")]
    public float coinValue;
    public float coinPerSecond = 1f;
    public float upgradeCost = 25f;
    public float upgradeCostBase = 25f;
    public float upgradeCostMultiplier = 1.5f;
    public int   upgradeLevel = 0;

    private void Update()
    {
        // Linear Coin Gain from time
        coinValue += coinPerSecond * Time.deltaTime;

        //UI Update
        coinTracker.text = "Coins: " + Mathf.FloorToInt(coinValue).ToString();  
        coinGenerationTracker.text = "Coins Per second: " + coinPerSecond.ToString("F1");
    }

    private void Start()
    {
        coinPerSecond = 1f;
    }

    public void Upgrade() 
    {
        if (coinValue >= upgradeCost)
        {
            coinValue -= upgradeCost;
            upgradeLevel++;
            upgradeCost = upgradeCostBase * Mathf.Pow(upgradeCostMultiplier, upgradeLevel); // exponential cost increase
            upgradeCostTracker.text = "Upgrade Cost: " + Mathf.FloorToInt(upgradeCost).ToString();
            upgradeLevelTracker.text = "Coin Generator+ Level: " + upgradeLevel.ToString();
        }

        else 
        {
            status.text = "Not enough coins to upgrade!";
        }
    }
}
