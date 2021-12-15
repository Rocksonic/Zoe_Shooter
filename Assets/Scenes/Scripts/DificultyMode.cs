using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DificultyMode : MonoBehaviour
{
    public GameObject UiDificulty;
    public GameObject PauseMenu;
    public GameObject[] Spawner;
    public Text textDificulty;
    public List<float> DificultyEasy;
    public List<float> DificultyNormal;
    public List<float> DificultyHard;
    public List<float> DificultyMaster;

    public int idSelected;

    private float[] Easy;
    private float[] Normal;
    private float[] Hard;
    private float[] Master;
    // Start is called before the first frame update
    private void Awake() {
        idSelected = 0;
    }

    void Start()
    {
        Easy = DificultyEasy.ToArray();
        Normal = DificultyNormal.ToArray();
        Hard = DificultyHard.ToArray();
        Master = DificultyMaster.ToArray();

        selectNormalMode();
    }

    public void selectEasyMode(){
        LoadData();
        Spawner[idSelected].GetComponent<Spawner>()._difficultyMultiplierDamage = Easy[0];
        Spawner[idSelected].GetComponent<Spawner>()._difficultyMultiplierHealth = Easy[1];

        textDificulty.text = "Easy Mode";
    }

    public void selectNormalMode(){
        LoadData();
        Spawner[idSelected].GetComponent<Spawner>()._difficultyMultiplierDamage = Normal[0];
        Spawner[idSelected].GetComponent<Spawner>()._difficultyMultiplierHealth= Normal[1];

        textDificulty.text = "Normal Mode";
    }

    public void selectHardMode(){
        LoadData();
        Spawner[idSelected].GetComponent<Spawner>()._difficultyMultiplierDamage = Hard[0];
        Spawner[idSelected].GetComponent<Spawner>()._difficultyMultiplierHealth = Hard[1];

        textDificulty.text = "Hard Mode";
    }

    public void selectMasterMode(){
        LoadData();
        Spawner[idSelected].GetComponent<Spawner>()._difficultyMultiplierDamage = Master[0];
        Spawner[idSelected].GetComponent<Spawner>()._difficultyMultiplierHealth = Master[1];

        textDificulty.text = "Master Mode";
    }

    public void LoadData()
    {
        idSelected = PlayerPrefs.GetInt("Object_Dificulty", 0);
    }

    public void closeUi()
    {
        PauseMenu.GetComponent<PauseMenu>().ResumeGame();
        UiDificulty.SetActive(false);
    }
}
