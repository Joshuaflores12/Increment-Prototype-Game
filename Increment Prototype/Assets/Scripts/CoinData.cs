using UnityEngine;
using TMPro;
using System.Collections;
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
    public TextMeshProUGUI statusTracker;

    [Header("Values")]
    public float coinValue;
    public float coinPerSecond;
    public float upgradeCost;
    public float upgradeCostBase;
    public float upgradeCostMultiplier;
    public float upgradeBonusMultiplier;
    public int   upgradeLevel;
    public int   maxUpgradeLevel = 5;

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
        upgradeLevel = 1;
    }


    // Handles the Formulation testing logic for linear, exponential, and multiplicative coin gain and upgrade cost increase
    public void Upgrade() 
    {
        // Check Upgrade Level Cap
        if (upgradeLevel >= maxUpgradeLevel)
        {
            statusTracker.gameObject.SetActive(true);
            statusTracker.text = "Maximum upgrade level reached!";
            StartCoroutine(HideStatusMessage(0.5f));
            return;
        }

        // Apply the upggrade effect and cost increase only if the player has enough coins to purchase the upgrade. If the player does not have enough coins, display a message indicating that they cannot afford the upgrade.
        if (coinValue >= upgradeCost && upgradeLevel < maxUpgradeLevel)
        {
            coinValue -= upgradeCost;

            upgradeLevel++;

            upgradeLevelTracker.text = "Coin Generator+ Level: " + upgradeLevel.ToString();


            upgradeCost = upgradeCostBase * Mathf.Pow(upgradeCostMultiplier, upgradeLevel);// Exponential cost increase

            upgradeCostTracker.text = Mathf.FloorToInt(upgradeCost).ToString();

            CoinGenerator(); // Apply the coin generation increase from the upgrade
        }

        else
        {
            statusTracker.gameObject.SetActive(true);
            statusTracker.text = "Not enough coins to upgrade!";
            StartCoroutine(HideStatusMessage(0.5f));

            upgradeCost = upgradeCost; // Keep the cost the same at max level
            statusTracker.text = "Maximum upgrade level reached!";
        }
    }


    public void CoinGenerator() 
    {
        if (upgradeLevel < maxUpgradeLevel)

            coinPerSecond *= (1 + upgradeBonusMultiplier); // Multiplicative coin gain increase
    }

    public IEnumerator HideStatusMessage(float duration) // Hides the status message after pressing upgrade button for a short duration, allowing the player to see the message before it disappears.
    {
        yield return new WaitForSeconds(duration);

        statusTracker.gameObject.SetActive(false);
    }
}
