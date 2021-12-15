using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectorPlayer : MonoBehaviour
{
    
    public List<GameObject> ListPlayerSkins;
    private GameObject[] ArrayListPlayerSkins;
    public GameObject ButtonPlay;
    public GameObject ButtonBuy;

    public int Crypto;
    public int coins;

    public Text TutorialText;
    public int TutorialActive = 1;

    public int[,] ShopSkins = new int[4,4];
    public int IdPlayerElegido = 0;

    private void Awake()
    {
        LoadData();
        PlayerPrefs.SetInt("id", 0);
        TutorialText.text = "Tutorial Active";
    }

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.None;
        ArrayListPlayerSkins =  ListPlayerSkins.ToArray();

        //ID's
        ShopSkins[1, 0] = 0;
        ShopSkins[1, 1] = 1;
        ShopSkins[1, 2] = 2;
        ShopSkins[1, 3] = 3;

        //Value
        ShopSkins[2, 0] = 0;
        ShopSkins[2, 1] = 55;
        ShopSkins[2, 2] = 100;
        ShopSkins[2, 3] = 200;

        //Quantity
        ShopSkins[3, 0] = 0;
        ShopSkins[3, 1] = 1;
        ShopSkins[3, 2] = 1;
        ShopSkins[3, 3] = 1;

    }

    public void ShowCharacter()
    {
        
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("SelectPlayer").GetComponent<EventSystem>().currentSelectedGameObject;
        for (var i = 0; i < ArrayListPlayerSkins.Length; i++)
        {
            //ArrayListPlayerSkins[i].SetActive(false);
        }

        //ArrayListPlayerSkins[ButtonRef.GetComponent<ButtonInfoSkins>().ItemID].SetActive(true);
        IdPlayerElegido = ButtonRef.GetComponent<ButtonInfoSkins>().ItemID;


        if (ShopSkins[3, IdPlayerElegido ] == 0)
        {
            ButtonPlay.SetActive(true);
            ButtonBuy.SetActive(false);
        }
        else
        {
            ButtonPlay.SetActive(false);
            ButtonBuy.SetActive(true);
        }
        
    } 

    public void BuySkin()
    {
        if (Crypto >= ShopSkins[2, IdPlayerElegido] && ShopSkins[3, IdPlayerElegido] > 0)
        {
            Crypto -= ShopSkins[2, IdPlayerElegido];
            ShopSkins[3, IdPlayerElegido]--;
        }

         if (ShopSkins[3, IdPlayerElegido ] == 0)
        {
            ButtonPlay.SetActive(true);
            ButtonBuy.SetActive(false);
        }
        else
        {
            ButtonPlay.SetActive(false);
            ButtonBuy.SetActive(true);
        }
    }

     private void SaveData()
    {
        PlayerPrefs.SetInt("id", IdPlayerElegido);
        PlayerPrefs.SetInt("Coin", coins);
        PlayerPrefs.SetInt("TutorialActive", TutorialActive);
        PlayerPrefs.SetInt("Crypto", Crypto);
    }

    private void LoadData()
    {
        coins = PlayerPrefs.GetInt("Coin", 0);
        Crypto = PlayerPrefs.GetInt("Crypto", 0);
        Crypto = 100000; //sacar luego
    }

    private void OnDestroy() {
        SaveData();
    }

    public void SwichTutorial()
    {
        if (TutorialActive == 0)
        {
            TutorialText.text = "Tutorial Active";
            TutorialActive = 1;
        }
        else
        {
            TutorialText.text = "Tutorial Disabled";
            TutorialActive = 0;
        }
    }
}
