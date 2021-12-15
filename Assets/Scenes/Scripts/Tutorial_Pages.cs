using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Pages : MonoBehaviour
{
    public GameObject PauseGame;

    public void HidePage(GameObject Page_Actual)
    {
        Page_Actual.SetActive(false);
    }

    public void ShowPage(GameObject Page_Actual)
    {
        Page_Actual.SetActive(true);
    }

    public void Finish()
    {
        gameObject.SetActive(false);
        PauseGame.GetComponent<PauseMenu>().ResumeGame();
        PauseGame.GetComponent<PauseMenu>()._inTutorial = false;
        
    }

}
