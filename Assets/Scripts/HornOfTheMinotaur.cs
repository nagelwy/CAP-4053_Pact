using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HornOfTheMinotaur : MonoBehaviour, Item
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

    bool charging;
    bool right;

    public float chargetime;
    float time;
    public float moveSpeed;
    public float CD;
    private float nextAbilityTime = 0;
    public float damagePerSpeed;

    void Start()
    {
        sm = GameObject.Find("GameStartManager").GetComponent<SelectionManager>();
        displayInfo();

    }
    void FixedUpdate()
    {
        if(charging)
        {
            if(time < chargetime)
            {
                time+= Time.deltaTime;
                pm.chargeDamage = damagePerSpeed;
                if(right)
                {
                    pm.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(moveSpeed, 0, 0); 
                }
                else
                {
                    pm.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-moveSpeed, 0, 0);
                }
            }
            else
            {
                time = 0;
                pm.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                charging = false;
                StartCoroutine(chargeIFrames());
            }
        }
    }
    IEnumerator chargeIFrames()
    {
        yield return new WaitForSeconds(0.25f);
        pm.charging = false;
    }
    public void displayInfo()
    {
        Title.text = titleString;
        Desc.text = descString;
        image.sprite = icon;
    }
    public void UpdateStats()
    {
        if(sm.phaseCounter == 0)
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
    public void UpdateItemStats(int index, float variable)
    {
        if(index == 0)
        {
            moveSpeed += variable;
        }
        else if(index == 1)
        {
            damagePerSpeed += variable;
        }
        else if(index == 2)
        {
            CD *= variable;
        }
    }
    public void onUse()
    {
            Debug.Log("This ability has been used");
            charging = true;
            pm.charging = true;


            if(pm.gameObject.GetComponent<PlayerMovement>().facingRight)
            {
            right = true;
            }
            else
            {
                right = false;
            }
    }
    public float getCD()
    {
        return CD;
    }
    public Sprite getIcon()
    {
        return icon;
    }
}
