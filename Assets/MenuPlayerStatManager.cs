using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuPlayerStatManager : MonoBehaviour
{
    [SerializeField] int coins;
    [SerializeField] int xp;
    [SerializeField] int Speed;
    [SerializeField] int Strength;
    [SerializeField] int AttackSpeed;
    [SerializeField] TextMeshProUGUI coinTextMeshPro;
    [SerializeField] TextMeshProUGUI xpTextMeshPro;
    [SerializeField] TextMeshProUGUI speedTextMeshPro;
    [SerializeField] TextMeshProUGUI strengthTextMeshPro;
    [SerializeField] TextMeshProUGUI attackSpeedTextMeshPro;
    [SerializeField] TMP_ColorGradient blue;
    [SerializeField] TMP_ColorGradient red;
    // Start is called before the first frame update
    void Start()
    {
        FetchSave();
    }
    public void BuyAttribute(int index, int numToAdd)
    {
        if (coins>=(numToAdd*100))
        {
            switch (index)
            {
                case 0:
                    Speed += numToAdd;
                    coins -= 100 * numToAdd;
                    coinTextMeshPro.text = coins.ToString();
                    speedTextMeshPro.text = Speed.ToString();
                    speedTextMeshPro.colorGradientPreset = red;
                    break;
                case 1:
                    Strength += numToAdd;
                    coins -= 100 * numToAdd;
                    coinTextMeshPro.text = coins.ToString();
                    strengthTextMeshPro.text = Strength.ToString();
                    strengthTextMeshPro.colorGradientPreset = red;
                    break;
                case 2:
                    AttackSpeed += numToAdd;
                    coins -= 100 * numToAdd;
                    coinTextMeshPro.text = coins.ToString();
                    attackSpeedTextMeshPro.text = AttackSpeed.ToString();
                    attackSpeedTextMeshPro.colorGradientPreset = red;
                    break;
                default:
                    break;
            }
        }
    }
    public void BuySpeedButton(int numToAdd)
    {
        BuyAttribute(0, numToAdd);
    }

    public void BuyStrengthButton(int numToAdd)
    {
        BuyAttribute(1, numToAdd);
    }
    public void BuyAttackSpeedButton(int numToAdd)
    {
        BuyAttribute(2, numToAdd);
    }
    public void Save()
    {
        PlayerPrefs.SetInt("xp", xp);
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("Speed", Speed);
        PlayerPrefs.SetInt("Strength", Strength);
        PlayerPrefs.SetInt("AttackSpeed", AttackSpeed);
        PlayerPrefs.Save();
        SetAllAtrributeBlue();
    }
    public void FetchSave()
    {
        if (PlayerPrefs.HasKey("xp"))
        {
            xp = PlayerPrefs.GetInt("xp");
            coins = PlayerPrefs.GetInt("coins");
            coinTextMeshPro.text = coins.ToString();
            xpTextMeshPro.text = xp.ToString();
        }
        if (PlayerPrefs.HasKey("Speed"))
        {
            Speed = PlayerPrefs.GetInt("Speed");
            speedTextMeshPro.text = Speed.ToString();
        }
        else
        {
            speedTextMeshPro.text = "0";
        }
        if (PlayerPrefs.HasKey("Strength"))
        {
            Strength = PlayerPrefs.GetInt("Strength");
            strengthTextMeshPro.text = Strength.ToString();
        }
        else
        {
            strengthTextMeshPro.text = "0";
        }
        if (PlayerPrefs.HasKey("AttackSpeed"))
        {
            AttackSpeed = PlayerPrefs.GetInt("AttackSpeed");
            attackSpeedTextMeshPro.text = AttackSpeed.ToString();
        }
        else
        {
            attackSpeedTextMeshPro.text = "0";
        }
        SetAllAtrributeBlue();
    }
    public void SetAllAtrributeBlue()
    {
        speedTextMeshPro.colorGradientPreset = blue;
        strengthTextMeshPro.colorGradientPreset = blue;
        attackSpeedTextMeshPro.colorGradientPreset = blue;
    }
}
