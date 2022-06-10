using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
// using UnityEngine.SceneManagement;
using TMPro;

public class Character : MonoBehaviour
{
    [SerializeField] LayerMask ground;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI coinTextFinish;
    [SerializeField] GameObject playerRifle;
    [SerializeField] private AudioSource jumpEffect;
    [SerializeField] private AudioSource hitEffect;
    [SerializeField] private AudioSource deathEffect;
    // [SerializeField] private AudioSource loseEffect;

    public HealthBar healthBarr;
    public CoinBar coinBarr;

    const float groundCheckRadius = 0.2f;
    private Rigidbody2D rb;
    private Animator anim;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    bool isHurting, isDead;
    private Vector3 localScale;
    bool IsGrounded = false;
    public int playerHealth = 100;
    public int currentHealth;
    public static int numberOfCoins;
    public int maxCoins;
    public GameObject DeadUI;   
        
    // Start is called before the first frame update
    void Start()
    {
        numberOfCoins = 0;
        healthText.text = playerHealth.ToString("0");
        coinText.text = numberOfCoins.ToString("0");
        coinTextFinish.text = numberOfCoins.ToString("0");
        currentHealth = playerHealth;
        healthBarr.SetMaxHealth(playerHealth);
        coinBarr.SetMaxCoins(maxCoins);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = numberOfCoins.ToString("0");
        coinTextFinish.text = numberOfCoins.ToString("0");
        coinBarr.SetCoins(numberOfCoins);
        if (!isDead)
        {
            dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
            if (IsGrounded)
            {
                // Debug.Log("adsada");
                playerRifle.gameObject.SetActive(true);
                GetComponent<Weapon>().enabled = true;
            }
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump") && !isDead && IsGrounded == true)
        {
            rb.AddForce(Vector2.up * 550f);
            jumpEffect.Play();
            // playerRifle.gameObject.SetActive(false);
            // GetComponent<Weapon>().enabled = false;                       
        }

        if (Mathf.Abs(dirX) > 0)
        {
            anim.SetBool("isRunning", true);
            // playerRifle.gameObject.SetActive(true);
        } else
        {
            anim.SetBool("isRunning", false);
            // playerRifle.gameObject.SetActive(true);
        }

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
            // playerRifle.gameObject.SetActive(true);            
        }

        if (rb.velocity.y > 5 && IsGrounded == false)
        {
            anim.SetBool("isJumping", true);
            playerRifle.gameObject.SetActive(false);
            GetComponent<Weapon>().enabled = false;
        }

        if (rb.velocity.y < -1 && IsGrounded == false)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
            playerRifle.gameObject.SetActive(false);
            GetComponent<Weapon>().enabled = false;
        }
    }

    // private bool IsGrounded() {
    //     return transform.Find("GroundCheck").GetComponent<GroundCheck>().IsGrounded;
    // }

    void GroundCheck() {
        IsGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, ground);
        if (colliders.Length > 0){
            IsGrounded = true;
        }
    }
    
    private void FixedUpdate() {
        GroundCheck();
        if (!isHurting){
            rb.velocity = new Vector2(dirX, rb.velocity.y);
        }
        if (dirX > 0 && !facingRight)
        {
            Flip();
        } else if (dirX < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip() {
        // if (dirX > 0)
        // {
        //     facingRight = true;
        // } else if (dirX < 0)
        // {
        //     facingRight = false;
        // }

        // if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        // {
        //     localScale.x *= -1;
            
        // }
        // transform.localScale = localScale;

        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public void UpdateHealth()
    {     
        healthText.text = currentHealth.ToString("0");
        healthBarr.SetHealth(currentHealth);
        if (currentHealth <= 0){
            dirX = 0;
            isDead = true;
            deathEffect.Play();
            playerRifle.gameObject.SetActive(false);
            anim.SetTrigger("isDead");
            StartCoroutine ("Die");
            Debug.Log("Game Over");
        }
        else{
            anim.SetTrigger ("isHurting");
            hitEffect.Play();
            StartCoroutine ("Hurt");
        }
    }

    IEnumerator Hurt()
    {
        isHurting = true;
        rb.velocity = Vector2.zero;
        playerRifle.gameObject.SetActive(false);
        if (facingRight){
            rb.AddForce (new Vector2(-200f, 300f));
        }
        else{
            rb.AddForce (new Vector2(200f, 300f));
        }
        yield return new WaitForSeconds(0.5f);
        isHurting = false;
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        // loseEffect.Play();
        Destroy(gameObject);
        DeadUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
 