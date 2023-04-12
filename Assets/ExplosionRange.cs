using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionRange : MonoBehaviour,Upgrade
{
    public int itemIndex;
    public float rangeUp;
    public string Title;
    public string Desc;
    public void onEquip()
    {
        GameObject exp = gameObject.GetComponentInParent<UpgradeManager>().getItem(itemIndex);
        exp.GetComponent<Item>().UpdateItemStats(1,rangeUp);
    }
    public void fillUI(Text title, Text desc)
    {
        title.text = Title;
        desc.text = Desc;
    }
}
