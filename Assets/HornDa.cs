using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HornDa : MonoBehaviour,Upgrade
{
    public int itemIndex;
    public float variable;
    public string Title;
    public string Desc;

    public void onEquip()
    {
        GameObject horn = gameObject.GetComponentInParent<UpgradeManager>().getItem(itemIndex);
        horn.GetComponent<Item>().UpdateItemStats(1,variable);
    }
    public void fillUI(Text title, Text desc)
    {
        title.text = Title;
        desc.text = Desc;
    }
}
