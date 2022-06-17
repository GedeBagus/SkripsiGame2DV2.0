using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float agroRange;   
    [SerializeField] float moveSpeed;
    [SerializeField] private Character character;
    [SerializeField] private AudioSource deathEffect;
    [SerializeField] private AudioSource boomEffect;
    public GameObject enemyBoomberBoom;
    public GameObject enemyBoomberHand;
    public int health = 100;
	private Animator anim;
    Rigidbody2D rb;
    private int enemy1Damage = 60;
    bool isBooming, dead;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0 && dead == false)
		{
			Die();
		}
	}

    void Die ()
	{
		dead = true;
        Collider2D col = gameObject.GetComponent<Collider2D>();
        col.isTrigger = false;
        deathEffect.Play();
        ScoreLevel.instance.addScore(40);
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        // rb.velocity = Vector2.zero;
        moveSpeed = 0f;
        enemyBoomberBoom.SetActive(false);
        enemyBoomberHand.SetActive(false);
        anim.SetTrigger("isDead");
		StartCoroutine ("isDead");
		// Destroy(gameObject);
	}

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange)
        {
            ChasePlayer();
            anim.SetBool("isRunning", true);
        }

        else
        {
            StopChase();
            anim.SetBool("isRunning", false);
        }
    }

    private void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            // rb.velocity = new Vector2(moveSpeed, 0);
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector2(2 , 2);
        }

        else 
        {
            // rb.velocity = new Vector2(-moveSpeed, 0);
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector2(-2, 2);
        }
    }

    private void StopChase()
    {
        rb.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player") && isBooming == false)
        {
        // rb.velocity = Vector2.zero;
        moveSpeed = 0f;
        boomEffect.Play();
        enemyBoomberBoom.SetActive(false);
        enemyBoomberHand.SetActive(false);
        anim.SetTrigger("isBoom");
		StartCoroutine ("isBoom");
        // Debug.Log("kena player");
        }
    }

    IEnumerator isBoom()
    {
        Debug.Log("kena player");
        isBooming = true;
        character.currentHealth = character.currentHealth - enemy1Damage;
        character.UpdateHealth();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }  

    IEnumerator isDead()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }  
}
