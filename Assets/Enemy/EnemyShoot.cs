using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private Character character;
    [SerializeField] float agroRange;
    [SerializeField] private AudioSource shootEffect;
    [SerializeField] private AudioSource deathEffect;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject enemyShooterGun;
    public GameObject enemyShooterHand;

    public int health = 100;
    private int enemyHitDamage = 10;
    bool isShooting, facingRight, crRunning, isDie;
	private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        isShooting = true;
        facingRight = true;
    }

    public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0 && isDie == false)
		{
			Die();
		}
	}

    void Die ()
	{
		Collider2D col = gameObject.GetComponent<Collider2D>();
        col.isTrigger = false;
        deathEffect.Play();
        ScoreLevel.instance.addScore(40);
        enemyShooterGun.SetActive(false);
        enemyShooterHand.SetActive(false);
        isDie = true;
        anim.SetTrigger("isDead");
        StartCoroutine ("isDead");
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
		// Destroy(gameObject);
	}

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer <= agroRange)
        {
            if(transform.position.x < player.position.x && !facingRight) 
            {
                Flip();
            }

            else if (transform.position.x > player.position.x && facingRight)
            {
                Flip();
            }

            if(isShooting && isDie == false)
            {
                StartCoroutine(ShootPlayer());
            }
        }
    }

    private void Flip() {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player") && crRunning == false)
        {
		StartCoroutine ("isHit");
        }
    }

    IEnumerator isHit()
    {
        Debug.Log("kena player");
        crRunning = true;
        character.currentHealth = character.currentHealth - enemyHitDamage;
        character.UpdateHealth();
        yield return new WaitForSeconds(0.5f);
        crRunning = false;
    }  

    IEnumerator ShootPlayer()
    {
        isShooting = false;
        shootEffect.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Debug.Log("Shoot");
        yield return new WaitForSeconds(2f);
        isShooting = true;
    }

    IEnumerator isDead()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }  
}
