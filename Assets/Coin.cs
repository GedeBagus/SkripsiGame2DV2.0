using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
   [SerializeField] private AudioSource coinsEffect;
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Character.numberOfCoins++;
            coinsEffect.Play();
            // PlayerPrefs.SetInt("StoredSystemCoins", Character.numberOfCoins);
            ScoreLevel.instance.addScore(10);
            // PlayerPrefs.SetInt("StoredLevelScores", ScoreLevel.scoreLevel);
            Destroy(gameObject);
        }
    }
}
