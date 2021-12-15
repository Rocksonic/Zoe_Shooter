using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfoSkill : MonoBehaviour
{
    public int ItemID;
    public Text ValueTxt;
    public Text QuantityTxt;
    public GameObject ShopManager;

    void Update()
    {
        ValueTxt.text = "Price: $" + ShopManager.GetComponent<ShopManagerScript>().shopSkills[2, ItemID].ToString();
        QuantityTxt.text = "Quantity: " + ShopManager.GetComponent<ShopManagerScript>().shopSkills[3, ItemID].ToString();
    }
}
