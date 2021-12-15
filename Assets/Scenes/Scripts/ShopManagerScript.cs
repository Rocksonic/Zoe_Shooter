using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    public List<GameObject> Weapons;
    public GameObject PlayerController;


    public int[,] shopItems = new int[5,5];
    public int[,] shopSkills = new int[5,5];
    public int coins;
    public Text CoinsTXT;

    public int Crypto;
    public Text CryptoTXT;

    public float ExtraDMG = 5;
    public int ExtraAmmo = 30;
    public float ExtraMaxHealth = 15;

    public int ValueItem1;
    public int ValueItem2;

    private void Awake() {
        LoadData();
    }

    void Start()
    {
        CoinsTXT.text = "Coins:" + coins.ToString();
        CryptoTXT.text = "Crypto:" + Crypto.ToString();

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;

        shopSkills[1, 1] = 1;
        shopSkills[1, 2] = 2;
        shopSkills[1, 3] = 3;

        //Value
        shopItems[2, 1] = ValueItem1;
        shopItems[2, 2] = ValueItem2;

        shopSkills[2, 1] = 100;
        shopSkills[2, 2] = 200;
        shopSkills[2, 3] = 30;

        //Quantity
        shopItems[3, 1] = 1;
        shopItems[3, 2] = 1;

        shopSkills[3, 1] = 15;
        shopSkills[3, 2] = 15;
        shopSkills[3, 3] = 30;

    }

    public void Sell()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID] > 0)
        {
            if (shopItems[1, ButtonRef.GetComponent<ButtonInfo>().ItemID] == 1)
            {
                coins += shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
                shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]--;
                CoinsTXT.text = "Coins: " + coins.ToString();
                ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = "Quantity: " + shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            }
            else if (shopItems[1, ButtonRef.GetComponent<ButtonInfo>().ItemID] == 2)
            {
                Crypto += shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
                shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]--;
                CryptoTXT.text = "Crypto: " + Crypto.ToString();
                ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = "Quantity: " + shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            }

        }
    }
    

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopSkills[2, ButtonRef.GetComponent<ButtonInfoSkill>().ItemID] && shopSkills[3, ButtonRef.GetComponent<ButtonInfoSkill>().ItemID] > 0)
        {
            coins -= shopSkills[2, ButtonRef.GetComponent<ButtonInfoSkill>().ItemID];
            shopSkills[3, ButtonRef.GetComponent<ButtonInfoSkill>().ItemID]--;
            CoinsTXT.text = "Coins:" + coins.ToString();
            ButtonRef.GetComponent<ButtonInfoSkill>().QuantityTxt.text = shopSkills[3, ButtonRef.GetComponent<ButtonInfoSkill>().ItemID].ToString();

            if (shopSkills[1, ButtonRef.GetComponent<ButtonInfoSkill>().ItemID] == 1)
            {
                foreach (GameObject weapon in Weapons)
                {
                    if (weapon.gameObject.active)
                    {
                        weapon.GetComponent<ScriptGun>().damage += ExtraDMG;
                    }
                 }
            }

            if (shopSkills[1, ButtonRef.GetComponent<ButtonInfoSkill>().ItemID] == 2)
            {
                PlayerController.GetComponent<PlayerController>().maxHealth += ExtraMaxHealth;
                PlayerController.GetComponent<PlayerController>().currentHealth += ExtraMaxHealth;
                HealthScript.UpdateHealthBar();
            }

            if (shopSkills[1, ButtonRef.GetComponent<ButtonInfoSkill>().ItemID] == 3)
            {
                foreach (GameObject weapon in Weapons)
                {
                    if (weapon.gameObject.active)
                    {
                        weapon.GetComponent<ScriptGun>().maxAmmo += ExtraAmmo;
                    }
                 }
            }
        }
    }


    public void UpdateInventory(int Quantity, int NumItem )
    {
        shopItems[3, NumItem] += Quantity;
    }
    

    private void SaveData()
    {
        PlayerPrefs.SetInt("Coin", coins);
        PlayerPrefs.SetInt("Crypto", Crypto);
    }

    private void LoadData()
    {
        coins = PlayerPrefs.GetInt("Coin", 0);
        Crypto = PlayerPrefs.GetInt("Crypto", 0);
    }

    private void OnDestroy() {
        SaveData();
    }

}
