using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigAttack : MonoBehaviour, Item
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
    public LayerMask enemyLayers;
    public LayerMask bossLayers;
    public Sprite icon;
    public float CD;
    public float damageMult;
    public float knockbackMult;

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
        PlayerCombat playerc = GameObject.Find("Player").GetComponent<PlayerCombat>();
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
        }
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
