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
    public float bowForce;
    public float Damage;

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
    public void onUse()
    {
        Debug.Log("This ability has been used");
        //bow fire animation
        if(pm.gameObject.GetComponent<PlayerMovement>().facingRight)
        {
            GameObject arrow;
            if(explosive)
            {
                arrow = Instantiate(arrows[1],pm.arrowPos.transform.position,Quaternion.identity);
            }
            else
            {
                arrow = Instantiate(arrows[0],pm.arrowPos.transform.position,Quaternion.identity);
            }
            arrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(bowForce,0));
            arrow.GetComponent<Arrow>().damage = Damage;
        }
        else
        {
            GameObject arrow;
            if(explosive)
            {
                arrow = Instantiate(arrows[1],pm.arrowPos.transform.position,Quaternion.identity);
            }
            else
            {
                arrow = Instantiate(arrows[0],pm.arrowPos.transform.position,Quaternion.identity);
            }
            arrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bowForce,0));
            arrow.GetComponent<Arrow>().damage = Damage;
        }
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
