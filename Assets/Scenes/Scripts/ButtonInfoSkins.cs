using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfoSkins : MonoBehaviour
{
    public int ItemID;
    public Text ValueTxt;
    public GameObject SelectorPlayer;

    void Update()
    {
        ValueTxt.text = "Price: $" + SelectorPlayer.GetComponent<SelectorPlayer>().ShopSkins[2, ItemID].ToString();
    }
}
