using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool _isGamePaused = false;
    bool _inPauseMenu;
    bool _inOptionMenu;
    public bool _inTutorial;
    public bool _inStore;

    public GameObject pauseMenuUI;
    public GameObject optionMenuUI;
    public GameObject HUD;
    public GameObject TutorialUI;
    public GameObject StoreUI;
    public GameObject DificultyUI;

    void Awake()
    {
        _inPauseMenu = false;
        _inOptionMenu = false;

        pauseMenuUI.SetActive(false);
        HUD.SetActive(true);
        optionMenuUI.SetActive(false);
        TutorialUI.SetActive(false);
        StoreUI.SetActive(false);
        DificultyUI.SetActive(false);

        _inTutorial = false;
        _inStore = false;

        
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("TutorialActive", 0) == 1)
        {
            Tutorial();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !(_inTutorial) && !(_inStore))
        {
            if (_isGamePaused && _inPauseMenu )
            {   
                ResumeGame();
            }

            else if (_inOptionMenu)
            {
                GoBack();
            }

            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        CrosshairController.ActivateCrosshair();
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        _inPauseMenu = false;
        _inOptionMenu = false;
        _isGamePaused = false;
    }

    void PauseGame()
    {
        CrosshairController.DeactivateCrosshair();
        Time.timeScale = 0f;
        HUD.SetActive(false);
        pauseMenuUI.SetActive(true);
        _isGamePaused = true;
        _inPauseMenu = true;
        _inOptionMenu = false;
    }

    public void ShowOptionMenu()
    {
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(true);
        _isGamePaused = true;
        _inPauseMenu = false;
        _inOptionMenu = true;
    }

    public void GoBack()
    {
        optionMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        _isGamePaused = true;
        _inPauseMenu = true;
        _inOptionMenu = false;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("SelectorPlayer", LoadSceneMode.Single);
        Time.timeScale = 1f;
        _isGamePaused = false;
    }

    public void Tutorial()
    {
        _inTutorial = true;
        CrosshairController.DeactivateCrosshair();
        Time.timeScale = 0f;
        _isGamePaused = true;
        
        HUD.SetActive(false);
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(false);
        TutorialUI.SetActive(true);
        
    }

    public void Store()
    {
        _inStore = true;
        CrosshairController.DeactivateCrosshair();
        Time.timeScale = 0f;
        _isGamePaused = true;
        
        HUD.SetActive(false);
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(false);
        StoreUI.SetActive(true);
        
    }

    public void Dificulty()
    {
        _inStore = true;
        CrosshairController.DeactivateCrosshair();
        Time.timeScale = 0f;
        _isGamePaused = true;
        
        HUD.SetActive(false);
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(false);
        DificultyUI.SetActive(true);
        
    }
}
