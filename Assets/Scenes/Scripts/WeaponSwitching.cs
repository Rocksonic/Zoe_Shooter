using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    public PauseMenu PauseMenu;
    public List<GameObject> listTypeWeapon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        selecWeapon();

        if (Input.GetAxis("Mouse ScrollWheel") > 0f && !(PauseMenu._isGamePaused)) 
        {
            if (selectedWeapon >= transform.childCount - 1 )
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f && !(PauseMenu._isGamePaused))
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }
    }

    void selecWeapon()
    {
        int i = 0;
        foreach (GameObject weapon in listTypeWeapon)
        {
            if(i != selectedWeapon )
            {
                weapon.gameObject.SetActive(false);
            }
            else
            {
                weapon.gameObject.SetActive(true);
            }
        i++;
        }
    }
}
