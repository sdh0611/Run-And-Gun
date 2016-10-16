using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public int health = 6;
    public int coinsCollected = 0;

    public bool isImmune = false;
    public float immunityDuration = 1.5f;
    private float immunityTime = 0f;

    private float flickerDuration = 0.1f;
    private float flickerTime = 0f;
    private SpriteRenderer spriteRenderer;

    private bool isDead = false;

    Rigidbody2D rb2D;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isImmune == true)
        {
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                isImmune = false;
                Debug.Log("Immunity has ended");
            }
        }
    }

    void SpriteFlicker() {
        if (flickerTime < flickerDuration)
        {
            flickerTime = flickerTime + Time.deltaTime;
        }
        else if (flickerTime >= flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            flickerTime = 0;
        }
    }

    public void CollectCoin(int coinValue)
    {
        coinsCollected = coinsCollected + coinValue;
    }

    public void TakeDamage(int damage, bool playHitReaction) {

        if (isImmune == false && isDead == false)
        {

            health = health - damage;
            Debug.Log("Player Health:" + health.ToString());

            if (health <= 0)
            {
                PlayerIsDead();
            }
            else if (playHitReaction == true)
            {
                PlayHitReaction();
            }

        }
    }

    void PlayerIsDead()
    {
        isDead = true;
        gameObject.GetComponent<Animator>().SetTrigger("Damage");
        PlayerController controller =
            gameObject.GetComponent<PlayerController>();
        controller.enabled = false;
        rb2D.velocity = new Vector2(0, 0);
        if (controller.isFacingRight == true)
        {
            rb2D.AddForce(new Vector2(-400, 400));
        }
        else
        {
            rb2D.AddForce(new Vector2(400, 400));
        }
    }

    void PlayHitReaction() {
        isImmune = true;
        immunityTime = 0f;
        gameObject.GetComponent<Animator>().SetTrigger("Damage");

    }
}
