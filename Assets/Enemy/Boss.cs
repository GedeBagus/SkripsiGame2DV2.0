using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Boss : MonoBehaviour
{
    // [SerializeField] Transform player;
    // [SerializeField] float attackRange;   
    // [SerializeField] float moveSpeed;
    // [SerializeField] private Character character;

    // public GameObject bossSword;
    // public GameObject bossHand;
    // public int health = 100;
	// private Animator anim;
    // Rigidbody2D rb;
    // private int enemy1Damage = 60;
    // bool isBooming, facingRight;
    
    // // Start is called before the first frame update
    // void Start()
    // {
    //     rb = GetComponent<Rigidbody2D>();
    //     anim = GetComponent<Animator>();
    // }

    // public void TakeDamage (int damage)
	// {
	// 	health -= damage;

	// 	if (health <= 0)
	// 	{
	// 		Die();
	// 	}
	// }

    // void Die ()
	// {
	// 	ScoreLevel.instance.addScore(40);
    //     // Instantiate(deathEffect, transform.position, Quaternion.identity);
    //     rb.velocity = Vector2.zero;
    //     bossSword.SetActive(false);
    //     bossHand.SetActive(false);
    //     anim.SetTrigger("isDead");
	// 	StartCoroutine ("isDead");
	// 	// Destroy(gameObject);
	// }

    // // Update is called once per frame
    // void Update()
    // {
    //     float distToPlayer = Vector2.Distance(transform.position, player.position);

    //     if (distToPlayer < attackRange && !facingRight)
    //     {
    //         Flip();
    //         ChasePlayer();
    //         anim.SetTrigger("Attack");
    //     }

    //     else
    //     {
    //         // StopChase();
    //         anim.ResetTrigger("Attack");
    //     }
    // }

    // private void ChasePlayer()
    // {
    //     if(transform.position.x < player.position.x)
    //     {
    //         // rb.velocity = new Vector2(moveSpeed, 0);
    //         transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
    //     }

    //     else 
    //     {
    //         // rb.velocity = new Vector2(-moveSpeed, 0);
    //         transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    //     }
    // }

    // private void Flip() {
    //     facingRight = !facingRight;
    //     transform.Rotate(0f, 180f, 0f);
    // }

    // private void OnTriggerEnter2D(Collider2D collision) 
    // {
    //     if (collision.CompareTag("Player") && isBooming == false)
    //     {
    //     rb.velocity = Vector2.zero;
    //     anim.SetTrigger("isBoom");
	// 	StartCoroutine ("isBoom");
    //     // Debug.Log("kena player");
    //     }
    // }

    // IEnumerator isBoom()
    // {
    //     Debug.Log("kena player");
    //     isBooming = true;
    //     character.currentHealth = character.currentHealth - enemy1Damage;
    //     character.UpdateHealth();
    //     yield return new WaitForSeconds(0.5f);
    //     isBooming = false;
    // }  

    // IEnumerator isDead()
    // {
    //     yield return new WaitForSeconds(1f);
    //     Destroy(gameObject);
    // }  
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
    // void update()
    // {
    //     bossBarr.SetBossHP(health);
    // }
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
        // if (collision.CompareTag("Player"))
        // {
        character.currentHealth = character.currentHealth - bossHitDmg;
        character.UpdateHealth();
        Debug.Log("kena player");
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
}
