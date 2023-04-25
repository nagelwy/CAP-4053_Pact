using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour, Item
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
    public GameObject[] arrows;
    public bool explosive;
    public float radius;
    public float bowForce;
    public float Damage;
    bool ab1or2;
    public bool charging;
    public string key;
    public float chargeTime;
    public float maxChargeTime;
    bool maxChargeReached;
    bool playerms;

    void Start()
    {
        sm = GameObject.Find("GameStartManager").GetComponent<SelectionManager>();
        displayInfo();

    }
    IEnumerator flash()
    {
        pm.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(0.1f);
        pm.GetComponent<SpriteRenderer>().color = Color.white;
    }
    void Update()
    {
        if(charging)
        {
            if(!playerms)
            {
                pm.MoveSpeed /= 2;
                playerms = true;
            }
            chargeTime += Time.deltaTime;
            if(chargeTime >= maxChargeTime && !maxChargeReached)
            {
                StartCoroutine(flash());
                maxChargeReached = true;
            }
            
            if (Input.GetAxis(key) == 0)
            {
                pm.bowcharge = true;
                if (pm.gameObject.GetComponent<PlayerMovement>().facingRight)
                {
                    GameObject arrow;
                    if (explosive)
                    {
                        arrow = Instantiate(arrows[1], pm.arrowPos.transform.position, Quaternion.identity);
                        arrow.GetComponent<Arrow>().radius = radius;
                    }
                    else
                    {
                        arrow = Instantiate(arrows[0], pm.arrowPos.transform.position, Quaternion.identity);
                    }
                    arrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(bowForce, 0));
                    if (maxChargeReached)
                    {
                        arrow.GetComponent<Arrow>().damage = Damage*maxChargeTime;
                    }
                    else
                    {
                        arrow.GetComponent<Arrow>().damage = Damage * chargeTime;
                    }
                }
                else
                {
                    GameObject arrow;
                    if (explosive)
                    {
                        arrow = Instantiate(arrows[1], pm.arrowPos.transform.position, Quaternion.identity);
                        arrow.GetComponent<Arrow>().radius = radius;
                    }
                    else
                    {
                        arrow = Instantiate(arrows[0], pm.arrowPos.transform.position, Quaternion.identity);
                    }
                    arrow.GetComponent<SpriteRenderer>().flipX = true;
                    arrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bowForce, 0));
                    if (maxChargeReached)
                    {
                        arrow.GetComponent<Arrow>().damage = Damage * maxChargeTime;
                    }
                    else
                    {
                        arrow.GetComponent<Arrow>().damage = Damage * chargeTime;
                    }
                }
                charging = false;
                maxChargeReached = false;
                pm.MoveSpeed *= 2;
                playerms = false;
                pm.gameObject.GetComponent<Animator>().SetBool("Bow",false);
            }          
        }
        else
        {
            pm = GameObject.Find("Player").GetComponent<PlayerManager>();
            pm.bowcharge = false;
        }
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
            key = "Ability 1";
        }
        else
        {
            pm = GameObject.Find("Player").GetComponent<PlayerManager>();
            pm.ability2 = this;
            key = "Ability 2";
        }
    }
    public void onUse()
    {
        Debug.Log("This ability has been used");
        //bow fire animation
        charging = true;
        chargeTime = 0;
        pm.gameObject.GetComponent<Animator>().SetBool("Bow",true);
    }
    public void UpdateItemStats(int index, float variable)
    {
        if(index == 0)
        {
            Damage += variable;
        }
        else if(index == 1)
        {
            bowForce += variable;
        }
        else if(index == 2)
        {
            explosive = true;
            radius += variable;
        }
        else if(index == 3)
        {
            CD *= variable;
        }
        else if(index == 4)
        {
            maxChargeTime *= variable;
        }
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
