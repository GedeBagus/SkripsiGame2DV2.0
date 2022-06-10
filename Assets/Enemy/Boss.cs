using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Boss : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] private Character character;
    [SerializeField] private AudioSource deathEffect;
    public GameObject bossHand, BossBarHP, area1, area2;
    public BossBar bossBarr;
    private Animator anim;
    public int health;
    int MaxHealth;
    private int bossHitDmg = 50;
	bool isFlipped, crRunning, isDie;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        MaxHealth = health;
        bossBarr.SetMaxBossHP(MaxHealth);
        healthText.text = MaxHealth.ToString("0");
    }
	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

    public void TakeDamage (int damage)
	{
		health -= damage;
        bossBarr.SetBossHP(health);
        healthText.text = health.ToString("0");

		if (health <= 0 && isDie == false)
		{
			Die();
            BossBarHP.SetActive(false);
            area1.SetActive(false);
            area2.SetActive(false);
		}
	}

    public void Attack ()
    {
        if (crRunning == false)
        {
            StartCoroutine ("Damage");
            Debug.Log("kena player");
        }
        // if (collision.CompareTag("Player"))
        // {
        // character.currentHealth = character.currentHealth - bossHitDmg;
        // character.UpdateHealth();
        // }
    }  

    void Die ()
	{
		deathEffect.Play();
        ScoreLevel.instance.addScore(500);
        bossHand.SetActive(false);
        isDie = true;
        anim.SetTrigger("isDead");
        StartCoroutine ("isDead");
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
		// Destroy(gameObject);
	}

    IEnumerator isDead()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    IEnumerator Damage()
    {
        crRunning = true;
        character.currentHealth = character.currentHealth - bossHitDmg;
        character.UpdateHealth();
        yield return new WaitForSeconds(1f);
        crRunning = false;
    }   
}
