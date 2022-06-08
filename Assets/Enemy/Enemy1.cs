using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int health = 100;
	private Animator anim;
	[SerializeField] private AudioSource deathEffect;
	float dirX, moveSpeed = 6f;
	bool moveRight = true;
	bool dead;
	public bool playerNear = false;

	// public GameObject deathEffect;
	void Start(){
		anim = GetComponent<Animator>();
	}

	// void update(){
	// 	if (Mathf.Abs(dirX) > 0)
    //     {
    //         anim.SetBool("isRunning", true);
    //     } 
	// }

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
		// GetComponent<Collider>().isTrigger = false;
		Collider2D col = gameObject.GetComponent<Collider2D>();
        col.isTrigger = false;
		deathEffect.Play();
		ScoreLevel.instance.addScore(20);
		moveSpeed = 0f;
		anim.SetTrigger("isDead");
		StartCoroutine ("isDead");
		// Instantiate(deathEffect, transform.position, Quaternion.identity);
		// Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D Area) {
        if (Area.CompareTag("Wall") || Area.CompareTag("Player"))
		{
			if (moveRight == true) {
				moveRight = false;
				transform.Rotate(0f, 180f, 0f);
			}
			else {
				moveRight = true;
				transform.Rotate(0f, 180f, 0f);
			}
		}
    }

    void Update () {
		if (moveRight && playerNear == true){
			transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
			anim.SetBool("isRunning", true);
		}
			
		else if (moveRight == false && playerNear == true){
			transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
			anim.SetBool("isRunning", true);
		}
			
	}

	IEnumerator isDead()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }  
}