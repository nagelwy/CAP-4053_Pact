using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] items;
    public UpgradeManager UM;
    bool calledOnce;
    public int index1;
    public int index2;

    void Start()
    {
        UM = GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>();
    }
    public void updateStat(int index)
    {
        items[index].GetComponent<Item>().UpdateStats();
        if(!calledOnce)
        {
            index1 = index;
            calledOnce = true;
        }
        else
        {
            index2 = index;
            UM.sendUpgrades(index1,index2);
        }
    }
}
