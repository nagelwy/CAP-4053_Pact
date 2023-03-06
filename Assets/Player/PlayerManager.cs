using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public PlayerCombat playerCombat;
    public PlayerMovement playerMovement;
    public SoundController sc;
    public float MaxHealth;
    public float currentHealth;
    public float MoveSpeed;
    public float AttackTime;
    public float Damage;
    public float time;
    private Rigidbody2D rb;
    public float CDR;
    public Pact pact;
    public Item ability1;
    public Item ability2;
    public float knockback;
    public Image[] icons;
    public int Level;
    public int xp;
    public int xpToLevel;

    public HealthBar healthBar;
    public XPBar xpBar;
    public bool charging;
    public float Ability1CD;
    public float ab1t;
    public float Ability2CD;
    public float ab2t;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        sc = GameObject.Find("SoundManager").GetComponent<SoundController>();

        currentHealth = MaxHealth;
        healthBar.setMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(ab1t > Ability1CD)
        {
            if(Input.GetAxis("Ability 1") != 0)
            {
                ability1.onUse();
                Ability1CD = ability1.getCD();
                ab1t = 0;
            }
        }
        else
        {
            ab1t += Time.deltaTime;
        }
        if(ab2t > Ability2CD)
        {
            if(Input.GetAxis("Ability 2") != 0)
            {
                ability2.onUse();
                Ability2CD = ability2.getCD();
                ab2t = 0;
            }
        }
        else
        {
            ab2t += Time.deltaTime;
        }

        if ( xp >= xpToLevel)
        {
            Debug.Log("Level up!");
            Level++;
            xp = 0;
        }
    }
    public void TakeDamage(int amount, int knockback, bool right)
    {
        if(!charging)
        {
            currentHealth -= amount;
            healthBar.setHealth(currentHealth);

            playerMovement.onHit = true;

            StartCoroutine(ColorChange());
            StartCoroutine(OnHitDelay(time));

            if(right)
            {
                rb.AddForce(new Vector2(-knockback, knockback / 2));
            }
            else
            {
                rb.AddForce(new Vector2(knockback, knockback / 2));
                
            }
            if(currentHealth <=0)
            {
                //die
                Debug.Log(gameObject.name +" is Dead!");
                
            }
        }
    }
    public void gainXP(float xp)
    {
        xpBar.setXP(xp);
    }
    public void BossDamage(int amount, float knockbackX, float knockbackY, bool right)
    {
        if(!charging)
        {
            currentHealth -= amount;

            playerMovement.onHit = true;

            StartCoroutine(ColorChange());
            StartCoroutine(OnHitDelay(time));

            if(right)
            {
                rb.AddForce(new Vector2(-knockbackX, knockbackY));
            }
            else
            {
                rb.AddForce(new Vector2(knockbackX, knockbackY));
                
            }
            if(currentHealth <=0)
            {
                //die
                Debug.Log(gameObject.name +" is Dead!");
                
            }
        }
    }
    private IEnumerator ColorChange()
    {
        sc.PlaySound(1);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    private IEnumerator OnHitDelay(float time)
    {
        yield return new WaitForSeconds(time);
        playerMovement.onHit = false;
    }

    public void UpdateIcons()
    {
        healthBar.setMaxHealth(MaxHealth);
        icons[0].sprite = pact.getIcon();
        icons[1].sprite = ability1.getIcon();
        icons[2].sprite = ability2.getIcon();
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(charging)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Enemy>().Hit(Mathf.Abs(rb.velocity.x)/3,knockback*2,playerMovement.facingRight);
            }
            if(collision.gameObject.tag == "Boss")
            {
                collision.gameObject.GetComponent<Boss>().Hit(Mathf.Abs(rb.velocity.x)/3);
            }
        }
    }
}
