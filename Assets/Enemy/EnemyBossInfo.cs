using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBossInfo : MonoBehaviour
{
    public GameObject EnemyUI, bossEffectUI, BossEnemy, BossEnemyHP, Area1, Area2;
    [SerializeField] private AudioSource buttonEffect;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            EnemyUI.SetActive(true);
        }
    }
    public void Close()
    {
        buttonEffect.Play();
        EnemyUI.SetActive(false);
        Area1.SetActive(true);
        Area2.SetActive(true);
        bossEffectUI.SetActive(true);
        StartCoroutine ("UIBOSS");
    }
    public void url()
    {
        Application.OpenURL("https://corona.jakarta.go.id/id/artikel/varian-varian-covid-19-apa-perbedaannya");
    }
    IEnumerator UIBOSS()
    {
        yield return new WaitForSeconds(3f);
        bossEffectUI.SetActive(false);
        BossEnemy.SetActive(true);
        BossEnemyHP.SetActive(true);
        Destroy(gameObject);
    } 
}
