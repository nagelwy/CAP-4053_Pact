using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowExplosion : MonoBehaviour,Upgrade
{
    public int itemIndex;
    
    public string Title;
    public string Desc;

    public void onEquip()
    {
        GameObject bow = gameObject.GetComponentInParent<UpgradeManager>().getItem(itemIndex);
        bow.GetComponent<Item>().UpdateItemStats(2,0f);
    }
    public void fillUI(Text title, Text desc)
    {
        title.text = Title;
        desc.text = Desc;
    }
}
