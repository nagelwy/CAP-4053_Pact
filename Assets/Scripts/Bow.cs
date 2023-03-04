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
        if(pm.gameObject.GetComponent<PlayerMovement>().facingRight)
        {
            pm.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(250f,0));
        }
        else
        {
            pm.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-250f,0));
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
