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
    public float numOfExtraExplosions;
    public float currentExplosionNum;
    public float powerCap;

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
            if(power > powerCap)
            {
                power = powerCap;
            }
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
        if(currentExplosionNum < numOfExtraExplosions)
        {
            currentExplosionNum++;
            StartCoroutine(RunItBack());
        }
        else
        {
            currentExplosionNum = 0;
        }
    }
    IEnumerator RunItBack()
    {
        yield return new WaitForSeconds(0.5f);
        onUse();
    }
    public void UpdateItemStats(int index, float variable)
    {
        if(index == 0)
        {
            damageMult += variable;
        }
        else if(index == 1)
        {
            range += variable;
        }
        else if(index == 2)
        {
            numOfExtraExplosions += variable;
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
