using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelPortal3 : MonoBehaviour
{
    public GameObject FinishUI;
    public GameObject Star2;
    public GameObject Star3;
    private int SceneLoad;
    void OnTriggerEnter2D(Collider2D other)
     {
        if (other.gameObject.CompareTag("Player"))
        {
            // SceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
            // SceneManager.LoadScene(SceneLoad);
            FinishUI.SetActive(true);
            Time.timeScale = 0f;
            if (ScoreLevel.scoreLevel >860)
            {
                Star2.SetActive(true);
            }
            if (ScoreLevel.scoreLevel >1100)
            {
                Star3.SetActive(true);
            }

            // int currentLevel = SceneManager.GetActiveScene().buildIndex;
            // if (currentLevel >= PlayerPrefs.GetInt("levelUnlocked"))
            // {
            //     PlayerPrefs.SetInt("levelUnlocked", currentLevel + 1);
            // }

            if(Character.numberOfCoins > PlayerPrefs.GetInt("Level3Coins"))
            {
                PlayerPrefs.SetInt("Level3Coins", Character.numberOfCoins);
            }  
        }
    }
}
