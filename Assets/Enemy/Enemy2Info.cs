using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2Info : MonoBehaviour
{
    public GameObject EnemyUI;
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
        Destroy(gameObject);
    }
    public void url()
    {
        Application.OpenURL("https://corona.jakarta.go.id/id/artikel/varian-varian-covid-19-apa-perbedaannya");
    }
}
