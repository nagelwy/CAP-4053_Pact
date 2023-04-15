using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawbackTime : MonoBehaviour,Upgrade
{
    public int itemIndex;
    public float variable;
    public string Title;
    public string Desc;
    public void onEquip()
    {
        GameObject exp = gameObject.GetComponentInParent<UpgradeManager>().getItem(itemIndex);
        exp.GetComponent<Item>().UpdateItemStats(4,variable);
    }
    public void fillUI(Text title, Text desc)
    {
        title.text = Title;
        desc.text = Desc;
    }
}
