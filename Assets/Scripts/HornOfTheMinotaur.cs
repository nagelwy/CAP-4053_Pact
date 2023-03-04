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
    float chargetime = 1f;
    float time; 
    float chargeaccel = 250f;
    public float CD;

    void Start()
    {
        sm = GameObject.Find("GameStartManager").GetComponent<SelectionManager>();
        displayInfo();

    }
    void Update()
    {
        if(charging)
        {
            if(time < chargetime)
            {
                Debug.Log(time);
                time+= Time.deltaTime;
                if(right)
                {
                    pm.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((chargeaccel*time)+10,0));
                }
                else
                {
                    pm.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-((chargeaccel*time)+10),0));
                }
            }
            else
            {
                time = 0;
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
