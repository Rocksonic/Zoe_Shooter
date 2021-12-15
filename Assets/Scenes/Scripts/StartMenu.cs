using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject _startMenu;
    public GameObject _optionsMenu;

    void Awake()
    {
        _startMenu.SetActive(true);
        _optionsMenu.SetActive(false);
    }


    public void GoToOptions()
    {
        _startMenu.SetActive(false);
        _optionsMenu.SetActive(true);
    }

    public void GoFromOptionsToStart()
    {
        _startMenu.SetActive(true);
        _optionsMenu.SetActive(false);
    }
}
