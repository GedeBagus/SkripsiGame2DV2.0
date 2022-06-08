using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy3Info : MonoBehaviour
{
    public GameObject EnemyUI;
    public GameObject enemytrigger1, enemytrigger2;
    [SerializeField] private AudioSource buttonEffect;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            EnemyUI.SetActive(true);
        }
    }

    // private void OnTriggerExit2D(Collider2D collision) {
    //     if (collision.CompareTag("Player"))
    //     {
    //         EnemyUI.SetActive(false);
    //         Destroy(gameObject);
    //         enemy1.playerNear = true;
    //         enemy1Body.SetActive(true);
    //     }
    // }
    public void Close()
    {
        Time.timeScale = 1f;
        buttonEffect.Play();
        EnemyUI.SetActive(false);
        enemytrigger1.SetActive(false);
        enemytrigger2.SetActive(false);
        // Destroy(gameObject);
        // enemy1.playerNear = true;
        // enemy1Body.SetActive(true);
    }
}
