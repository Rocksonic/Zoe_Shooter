using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreUI : MonoBehaviour
{
    public GameObject PauseMenu;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.layer == 6 && Input.GetKeyDown(KeyCode.E))
        {
            //InicioStore();
            PauseMenu.GetComponent<PauseMenu>().Store();
        }
    }

    public void InicioStore()
    {
        PauseMenu.GetComponent<PauseMenu>().Store();
    }
}
