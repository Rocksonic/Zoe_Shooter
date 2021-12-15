using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShop : MonoBehaviour
{

    public GameObject Shell_Item;
    public GameObject Shop_Skill;
    public GameObject PlaceCoin;
    public GameObject PauseMenu;
    public GameObject CanvasStore;

    // Update is called once per frame

    public void GoShell_Item()
    {
        Shell_Item.SetActive(true);
        Shop_Skill.SetActive(false);
        gameObject.SetActive(false);
        PlaceCoin.SetActive(true);
    }


    public void GoShop_Skill()
    {
        Shell_Item.SetActive(false);
        Shop_Skill.SetActive(true);
        gameObject.SetActive(false);
        PlaceCoin.SetActive(true);
    }

    public void GoMenuShop()
    {
        Shell_Item.SetActive(false);
        Shop_Skill.SetActive(false);
        gameObject.SetActive(true);
        PlaceCoin.SetActive(false);
    }

    public void GoBackToGame()
    {
        CanvasStore.SetActive(false);
        PauseMenu.GetComponent<PauseMenu>().ResumeGame();
    }

}
