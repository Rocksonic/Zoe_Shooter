using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour
{
    public static Text coins;
    public Text coinsNotStatic;
    
    void Awake()
    {
        coins = coinsNotStatic;
    }

    public static void ModifyCoinText()
    {
        coins.text = "Coins: " + PlayerPrefs.GetInt("coins");
    }
}
