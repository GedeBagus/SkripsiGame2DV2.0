using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy3Info : MonoBehaviour
{
    public GameObject EnemyUI;
    public GameObject enemytrigger1, enemytrigger2;
    [SerializeField] private AudioSource buttonEffect;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            EnemyUI.SetActive(true);
        }
    }
    public void Close()
    {
        Time.timeScale = 1f;
        buttonEffect.Play();
        EnemyUI.SetActive(false);
        enemytrigger1.SetActive(false);
        enemytrigger2.SetActive(false);
    }

    public void url()
    {
        Application.OpenURL("https://corona.jakarta.go.id/id/artikel/varian-varian-covid-19-apa-perbedaannya");
    }
}
