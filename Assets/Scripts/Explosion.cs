using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour, Item
{
    public GameObject ItemSelect;
    public Text Title;
    public Text Desc;
    public Button button;
    public Image image;
    public string titleString;
    public string descString;
    private PlayerManager pm;
    private SelectionManager sm;
    public Sprite icon;
    public float CD;
    public float range;
    public float damageMult;
    public float distanceMult;
    public LayerMask hittableLayer;

    void Start()
    {
        sm = GameObject.Find("GameStartManager").GetComponent<SelectionManager>();
        displayInfo();

    }
    public void displayInfo()
    {
        Title.text = titleString;
        Desc.text = descString;
        image.sprite = icon;
    }
    public void UpdateStats()
    {
        if (sm.phaseCounter == 0)
        {
            pm = GameObject.Find("Player").GetComponent<PlayerManager>();
            pm.ability1 = this;
        }
        else
        {
            pm = GameObject.Find("Player").GetComponent<PlayerManager>();
            pm.ability2 = this;
        }
    }
    public void onUse()
    {
        Debug.Log("BigAttack");
        RaycastHit2D[] enemiesHit = Physics2D.CircleCastAll(pm.gameObject.transform.position,range,new Vector2(0,0),0,hittableLayer);
        foreach(RaycastHit2D ray in enemiesHit)
        {
            float dist = Mathf.Sqrt(Mathf.Pow(ray.transform.position.x-pm.transform.position.x,2)+Mathf.Pow(ray.transform.position.y-pm.transform.position.y,2));
            float power = range - dist;
            Vector2 direction = new Vector2(ray.transform.position.x-pm.transform.position.x,ray.transform.position.y-pm.transform.position.y);
            ray.transform.gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized*power*distanceMult);
            if(ray.transform.gameObject.tag == "Enemy")
            {
                ray.transform.gameObject.GetComponent<Enemy>().currentHealth -= power*damageMult;
            }
            else if(ray.transform.gameObject.tag == "Boss")
            {
                ray.transform.gameObject.GetComponent<Boss>().currentHealth -= power*damageMult;
            }
        }

        /*PlayerCombat playerc = GameObject.Find("Player").GetComponent<PlayerCombat>();
        playerc.gameObject.GetComponent<PlayerMovement>().attacking = true;
        playerc.gameObject.GetComponent<Animator>().SetBool("bigAttack", true);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerc.attackPoint.position,1.5f,enemyLayers);
        Collider2D[] hitBoss = Physics2D.OverlapCircleAll(playerc.attackPoint.position,1.5f,bossLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<Enemy>().Hit(pm.Damage*damageMult,pm.knockback*knockbackMult,pm.gameObject.GetComponent<PlayerMovement>().facingRight);
        }
        foreach(Collider2D boss in hitBoss)
        {
            boss.gameObject.GetComponent<Boss>().Hit(pm.Damage*damageMult);
        }*/
    }
    public void UpdateItemStats(int index, float variable)
    {
        
    }
    public Sprite getIcon()
    {
        return icon;
    }
    public float getCD()
    {
        return CD;
    }
}
