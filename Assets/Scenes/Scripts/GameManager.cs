using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static int coins;
    public static int parts;
    public static int parts2;
    
    public List<int> _dropRate;
    public List<GameObject> _drops;
    public static int[] _dropRateArray;
    
    private static int provabilityWindow;
    
    public Dictionary<int,GameObject> dropTable;
    public static Dictionary<int,GameObject> realDropTable;
    
    public GameObject weapon;
    public GameObject HUD;
    
    public static GameObject realHUD;
    public static GameObject realWeapon;

    public Text highScoreText;
    public static Text realHighScoreText;
    

    void Awake()
    {
        realHighScoreText = highScoreText;
        realHighScoreText.text = PlayerPrefs.GetInt("MaxRounds").ToString();
        dropTable = _dropRate.Zip(_drops, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);

        PlayerPrefs.SetInt("parts", 0);
        PlayerPrefs.SetInt("parts2", 0);

        coins = PlayerPrefs.GetInt("coins");
        parts = PlayerPrefs.GetInt("parts");
        parts2 = PlayerPrefs.GetInt("parts2");
        realWeapon = weapon;
        realHUD = HUD;
        
        realDropTable = dropTable;
        _dropRateArray = _dropRate.ToArray();
        provabilityWindow = _dropRateArray.Max();
    }

    public static void ModifyCoinAmount(int coinAmount)
    {
        int temporalCoins = PlayerPrefs.GetInt("coins");
        PlayerPrefs.SetInt("coins", temporalCoins += coinAmount);
        coins = PlayerPrefs.GetInt("coins");
        CoinsText.ModifyCoinText();
    }

    public static void ModifyPartsAmount(int partsAmount)
    {
        int temporalParts = PlayerPrefs.GetInt("parts");
        PlayerPrefs.SetInt("parts", temporalParts += partsAmount);
        parts = PlayerPrefs.GetInt("parts");
        Debug.Log("You have: " + parts + " parts.");
    }

        public static void ModifyParts2Amount(int parts2Amount)
    {
        int temporalParts2 = PlayerPrefs.GetInt("parts2");
        PlayerPrefs.SetInt("parts2", temporalParts2 += parts2Amount);
        parts2 = PlayerPrefs.GetInt("parts2");
        Debug.Log("You have: " + parts2 + " parts.");
    }

    public static void DropLoot(Transform LootPosition)
    {
        int item = Random.Range(0, 101);
        
        if (item <= provabilityWindow)
        {
            item = FindClosest(_dropRateArray, item);
            Instantiate(realDropTable[item], LootPosition.transform.position, LootPosition.transform.rotation);
        }
    }


    // This is the pacific mode, it just hides the hud and the weapon
    public static void PacificMode(bool modeSelector)
    {
        if (modeSelector)
        {
            CrosshairController.DeactivateCrosshair();
            realWeapon.SetActive(false);
            realHUD.SetActive(false);
        }

        else
        {
            CrosshairController.ActivateCrosshair();
            realWeapon.SetActive(true);
            realHUD.SetActive(true);
        }
    }

    // A little bit of magic
    public static int FindClosest(int[] data, int value)
    {
        for (var i = 0; i < data.Length - 1; i++)
        {
            if (data[i] >= value && value >= data[i + 1])
                return data[i];
        }
        return data.Last();
    }

    public static void HighScore()
    {
        if (PlayerPrefs.GetInt("MaxRounds") <= RoundManager.roundCount)
        {
            PlayerPrefs.SetInt("MaxRounds", RoundManager.roundCount);
            realHighScoreText.text = PlayerPrefs.GetInt("MaxRounds").ToString();
        }
        Debug.Log("High Score is: " + PlayerPrefs.GetInt("MaxRounds"));
    }
}
