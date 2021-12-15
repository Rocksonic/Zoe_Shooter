using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultyUi : MonoBehaviour
{
    public GameObject PauseMenu;
    public int id;


    private void OnTriggerStay(Collider other) {
        if (other.gameObject.layer == 6 && Input.GetKeyDown(KeyCode.E))
        {
            //InicioStore();
            PauseMenu.GetComponent<PauseMenu>().Dificulty();
            SaveData();
        }
    }

    public void InicioStore()
    {
        PauseMenu.GetComponent<PauseMenu>().Dificulty();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Object_Dificulty", id);
    }
}
