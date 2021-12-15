using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateInventory : MonoBehaviour
{
    public GameObject ShopManager;
    public GameObject RoundManager;
    public GameObject _RoundCount;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            ShopManager.GetComponent<ShopManagerScript>().UpdateInventory(GameManager.parts, 1);
            ShopManager.GetComponent<ShopManagerScript>().UpdateInventory(GameManager.parts2, 2);
            RoundManager.GetComponent<RoundManager>().resetAll();
            GameManager.parts = 0;
            GameManager.parts2 = 0;
            _RoundCount.SetActive(false);
        }
    }
}
