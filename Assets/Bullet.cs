using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine ("Destroy");
    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        if (hitInfo.CompareTag("Ground") || hitInfo.CompareTag("Enemy") || hitInfo.CompareTag("Trap"))
		{
			Destroy(gameObject);
		}
        // if (hitInfo.CompareTag("Enemy")){
        //     Debug.Log(hitInfo.name);
        //     // Destroy(gameObject);
        // }

        Enemy1 enemy = hitInfo.GetComponent<Enemy1>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
            // Destroy(gameObject);
		}

        EnemyBomb enemyBomb = hitInfo.GetComponent<EnemyBomb>();
		if (enemyBomb != null)
		{
			enemyBomb.TakeDamage(damage);
            // Destroy(gameObject);
		}

        EnemyShoot enemyShoot = hitInfo.GetComponent<EnemyShoot>();
		if (enemyShoot != null)
		{
			enemyShoot.TakeDamage(damage);
		}

        Boss enemyBoss = hitInfo.GetComponent<Boss>();
		if (enemyBoss != null)
		{
			enemyBoss.TakeDamage(damage);
		}

        Debug.Log(hitInfo.name);
        // Destroy(gameObject);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    } 
}
