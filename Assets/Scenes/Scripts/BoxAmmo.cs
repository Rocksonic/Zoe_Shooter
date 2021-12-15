using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAmmo : MonoBehaviour
{
    public int capacityAmmo;
    public float timeLife;

    public GameObject[] Weapons;

    public void increaseAmmo(){
        Weapons = GameObject.FindGameObjectsWithTag("WeaponPlayer");
        for (int i = 0; i < Weapons.Length; i++)
            {
                Debug.Log("hello");
                if (Weapons[i].gameObject.active)
                    {
                        Weapons[i].GetComponent<ScriptGun>().maxAmmo += capacityAmmo;
                        Destroy(gameObject, 0f);
                    }
            }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            increaseAmmo();
        }
    }
}
