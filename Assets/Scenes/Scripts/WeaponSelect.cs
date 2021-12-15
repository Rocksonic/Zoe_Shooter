using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    public int IdPlayerElegido;
    private int VariableAuxiliar;
    
    private void Awake()
    {
        LoadData();
    }

    void Start()
    {
        selectionWeapon();
    }

    void Update()
    {
        if (!(IdPlayerElegido == VariableAuxiliar) )
        {
            selectionWeapon();
        }
    }

    public void selectionWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (weapon.gameObject.GetComponent<idWeapon>().Id == IdPlayerElegido)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
        
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("id", IdPlayerElegido);
    }

    private void LoadData()
    {
        IdPlayerElegido = PlayerPrefs.GetInt("id", 0);
        VariableAuxiliar = IdPlayerElegido; 
    }

    private void OnDestroy() {
        SaveData();
    }

}
