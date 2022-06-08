using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBossInfo : MonoBehaviour
{
    public GameObject EnemyUI, bossEffectUI, BossEnemy, BossEnemyHP, Area1, Area2;
    [SerializeField] private AudioSource buttonEffect;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            // Time.timeScale = 0f;
            EnemyUI.SetActive(true);
        }
    }

    public void Close()
    {
        buttonEffect.Play();
        // Time.timeScale = 1f;
        EnemyUI.SetActive(false);
        Area1.SetActive(true);
        Area2.SetActive(true);
        bossEffectUI.SetActive(true);
        StartCoroutine ("UIBOSS");
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
