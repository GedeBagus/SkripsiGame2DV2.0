using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    //https://www.youtube.com/watch?v=actCCLvJjPI
    [SerializeField] TextMeshProUGUI coinText1;
    [SerializeField] TextMeshProUGUI coinText2;
    [SerializeField] TextMeshProUGUI coinText3;
    [SerializeField] private AudioSource buttonEffect;
    public GameObject FirstPage;
    public GameObject LevelPage;
    public CoinBarStage1 coinBar1;
    public CoinBarStage2 coinBar2;
    public CoinBarStage3 coinBar3;
    public int maxCoins1, maxCoins2, maxCoins3;
    int levelUnlocked;
    public static bool FromGame;

    public Button[] buttons;
    
    // Start is called before the first frame update
    void Start()
    {
        levelUnlocked = PlayerPrefs.GetInt("levelUnlocked", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            buttons[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < levelUnlocked; i++)
        {
            buttons[i].interactable = true;
            buttons[i].gameObject.SetActive(true);
        }

        coinText1.text = PlayerPrefs.GetInt("Level1Coins").ToString("0");
        coinBar1.SetMaxCoins(maxCoins1);
        coinBar1.SetCoins(PlayerPrefs.GetInt("Level1Coins"));
        coinText2.text = PlayerPrefs.GetInt("Level2Coins").ToString("0");
        coinBar2.SetMaxCoins(maxCoins2);
        coinBar2.SetCoins(PlayerPrefs.GetInt("Level2Coins"));
        coinText3.text = PlayerPrefs.GetInt("Level3Coins").ToString("0");
        coinBar3.SetMaxCoins(maxCoins3);
        coinBar3.SetCoins(PlayerPrefs.GetInt("Level3Coins"));
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        buttonEffect.Play();
    }

    public void Play()
    {
        FirstPage.SetActive(false);
        LevelPage.SetActive(true);
        buttonEffect.Play();
    }

    public void BackPlay()
    {
        FirstPage.SetActive(true);
        LevelPage.SetActive(false);
        buttonEffect.Play();
    }
}
