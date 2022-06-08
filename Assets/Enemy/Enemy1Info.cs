using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1Info : MonoBehaviour
{
    public GameObject Enemy1UI;
    public GameObject enemy1Body;
    [SerializeField] private Enemy1 enemy1;
    [SerializeField] private AudioSource popUpEffect;
    [SerializeField] private AudioSource buttonEffect;
    
    // Start is called before the first frame update
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
            popUpEffect.Play();
            Enemy1UI.SetActive(true);
        }
    }

    // private void OnTriggerExit2D(Collider2D collision) {
    //     if (collision.CompareTag("Player"))
    //     {
    //         Enemy1UI.SetActive(false);
    //         Destroy(gameObject);
    //         enemy1.playerNear = true;
    //         enemy1Body.SetActive(true);
    //     }
    // }
    public void Close()
    {
        Time.timeScale = 1f;
        buttonEffect.Play();
        Enemy1UI.SetActive(false);
        // Destroy(gameObject);
        enemy1.playerNear = true;
        enemy1Body.SetActive(true);
        Destroy(gameObject);
    }
}
