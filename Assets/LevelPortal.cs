using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    // [SerializeField] private AudioSource winningEffect;
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
            // winningEffect.Play();
            Time.timeScale = 0f;
            if (ScoreLevel.scoreLevel >200)
            {
                Star2.SetActive(true);
            }
            if (ScoreLevel.scoreLevel >270)
            {
                Star3.SetActive(true);
            }

            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            if (currentLevel >= PlayerPrefs.GetInt("levelUnlocked"))
            {
                PlayerPrefs.SetInt("levelUnlocked", currentLevel + 1);
            }

            if(Character.numberOfCoins > PlayerPrefs.GetInt("Level1Coins"))
            {
                PlayerPrefs.SetInt("Level1Coins", Character.numberOfCoins);
            }  
        }
    }
}
