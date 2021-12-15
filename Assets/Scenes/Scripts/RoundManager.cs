using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public GameObject player;
    public GameObject Spawner;
    public GameObject Button;
    public Text RoundCountTXT;
    public int increaseAmountOfSpawns;
    public static int roundCount = 0;
    public bool lockRound = false;
    public bool lockCount = false;

    private int inicalMaximumAmountOfSpawns ;
    // Update is called once per frame

    private void Start() {
        inicalMaximumAmountOfSpawns = Spawner.GetComponent<Spawner>()._maximumAmountOfSpawns;
        RoundCountTXT.text = "Round :" + roundCount.ToString();
    }
    void Update()
    {
        if (((roundCount % 5) == 0) && lockCount && !(roundCount == 0) && !((roundCount % 4) == 0))
        {
            Spawner.GetComponent<Spawner>()._stopSpawning = true;
            Button.GetComponent<ButtonStartRound>().show();
            lockRound = false;
            lockCount = false;
            RoundCountTXT.text = "Round :" + roundCount.ToString();
        }
        else if (((roundCount % 4) == 0) && lockCount && !(roundCount == 0))
        {
            Spawner.GetComponent<Spawner>()._stopSpawning = true;
            lockRound = false;
            lockCount = false;
            RoundCountTXT.text = "Round :" + roundCount.ToString();
            Spawner.GetComponent<Spawner>().SpawnBoss();
        }
        else if ((Spawner.GetComponent<Spawner>()._maximumAmountOfSpawns == player.GetComponent<PlayerController>().kills) && lockCount && lockRound)
        {
            NextRound();
        }
    }

    public void NextRound()
    {
        roundCount++;
        GameManager.HighScore();
        Spawner.GetComponent<Spawner>().resetAmountSpawned();
        player.GetComponent<PlayerController>().resetKills();
        Spawner.GetComponent<Spawner>()._maximumAmountOfSpawns += increaseAmountOfSpawns;
        Spawner.GetComponent<Spawner>().StartSpawn();
        lockCount = true;
        lockRound = true;
        RoundCountTXT.text = "Round :" + roundCount.ToString();
    }

    public void resetAll()
    {
        roundCount = 0;
        lockRound = false;
        lockCount = false;
        player.GetComponent<PlayerController>().resetKills();
        Spawner.GetComponent<Spawner>().resetAmountSpawned();
        Spawner.GetComponent<Spawner>()._maximumAmountOfSpawns = inicalMaximumAmountOfSpawns;
        RoundCountTXT.text = "Round :" + roundCount.ToString();
    }
}
