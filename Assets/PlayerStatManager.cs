using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatManager : MonoBehaviour
{
    [SerializeField] int coins;
    [SerializeField] int xp;
    [SerializeField] int addiSpeed;
    [SerializeField] int addiStrength;
    [SerializeField] int addiAttackSpeed;
    [SerializeField] TextMeshProUGUI coinTextMeshPro;
    [SerializeField] TextMeshProUGUI xpTextMeshPro;
    [SerializeField] TextMeshProUGUI endCoinTextMeshPro;
    [SerializeField] TextMeshProUGUI endXpTextMeshPro;
    public int Coins { get { return coins; } }
    public int Xp { get { return xp; } }
    public int AddiSpeed { get { return addiSpeed; } }
    public int AddiStrength { get { return addiStrength; } }
    public int AddiAttackSpeed { get { return addiAttackSpeed; } }
    private void Start()
    {
        if (PlayerPrefs.HasKey("Speed"))
        {
            addiSpeed = PlayerPrefs.GetInt("Speed");
        }
        if (PlayerPrefs.HasKey("Strength"))
        {
            addiStrength = PlayerPrefs.GetInt("Strength");
        }
        if (PlayerPrefs.HasKey("AttackSpeed"))
        {
            addiAttackSpeed = PlayerPrefs.GetInt("AttackSpeed");
        }
    }

    public void AddCoins(int _addedCoin)
    {
        coins += _addedCoin;
        UpdateCoinDisplay();
    }
    public void AddXps(int _addedXp)
    {
        xp += _addedXp;
        UpdateXpDisplay();
    }
    public void MinusCoins(int _minusCoin)
    {
        coins -= _minusCoin;
        UpdateCoinDisplay();
    }
    public void MinusXps(int _minusXp)
    {
        xp -= _minusXp;
        UpdateXpDisplay();
    }
    public void ResetStat()
    {
        xp = 0;
        coins = 0;
    }
    public void Save()
    {
        endCoinTextMeshPro.text = coins.ToString();
        endXpTextMeshPro.text = xp.ToString();
        if (!PlayerPrefs.HasKey("xp"))//if no key, store
        {
            PlayerPrefs.SetInt("xp", xp);
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.Save();
        }
        else//if key, add value to key
        {
            int xpsToStore = PlayerPrefs.GetInt("xp");
            int coinsToStore = PlayerPrefs.GetInt("coins");
            xpsToStore += xp;
            coinsToStore += coins;
            PlayerPrefs.SetInt("xp", xpsToStore);
            PlayerPrefs.SetInt("coins", coinsToStore);
            PlayerPrefs.Save();
        }

    }
    private void UpdateCoinDisplay()
    {
        coinTextMeshPro.text = coins.ToString();
    }private void UpdateXpDisplay()
    {
        xpTextMeshPro.text = xp.ToString();
    }
}
