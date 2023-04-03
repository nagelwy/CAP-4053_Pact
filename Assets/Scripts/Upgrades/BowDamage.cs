using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowDamage : MonoBehaviour,Upgrade
{
    public int itemIndex;
    public float damageUp;
    public string Title;
    public string Desc;
    public void onEquip()
    {
        GameObject bow = gameObject.GetComponentInParent<UpgradeManager>().getItem(itemIndex);
        bow.GetComponent<Item>().UpdateItemStats(0,damageUp);
    }
    public void fillUI(Text title, Text desc)
    {
        title.text = Title;
        desc.text = Desc;
    }
}
