using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public PlayerCombat playerCombat;
    public PlayerMovement playerMovement;
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

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        currentHealth = MaxHealth;
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

        playerMovement.onHit = true;

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
