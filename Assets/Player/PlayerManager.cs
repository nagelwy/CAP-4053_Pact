using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public PlayerCombat playerCombat;
    public PlayerMovement playerMovement;
    public SoundController sc;
    public float MaxHealth = 10;
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
        if(Input.GetAxis("Ability 1") != 0)
        {
            ability1.onUse();
        }
        if(Input.GetAxis("Ability 2") != 0)
        {
            ability2.onUse();
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
    public void gainXP(float xp)
    {
        xpBar.setXP(xp);
    }
    public void BossDamage(int amount, float knockbackX, float knockbackY, bool right)
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
        icons[0].sprite = pact.getIcon();
        icons[1].sprite = ability1.getIcon();
        icons[2].sprite = ability2.getIcon();
    }
}
