using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // [SerializeField] private Character character;
    public float speed = 2f;
    public int damage = 25;
    public Rigidbody2D rb;
    bool crRunning;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine ("Destroy");
    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Ground") || hitInfo.CompareTag("Trap"))
		{
			Destroy(gameObject);
		}

        Character character = hitInfo.GetComponent<Character>();
		if (character != null)
		{
			character.currentHealth = character.currentHealth - damage;
            character.UpdateHealth();
		}

        Debug.Log(hitInfo.name);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    } 
}
