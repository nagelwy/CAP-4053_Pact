using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject[] items;
    public GameObject[] GenericUpgrades;
    public GameObject[] hornUpgrades;
    public GameObject[] explosionUpgrades;
    public GameObject[] bowUpgrades;
    public UpgradeOptions UO;
    public BowDamage bd;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("o"))
        {
            bd.onEquip();
        }
    }
    public void sendUpgrades(int index1, int index2)
    {
        List<GameObject> temp = new List<GameObject>();
        for (int i = 0; i < GenericUpgrades.Length; i++)
        {
            temp.Add(GenericUpgrades[i]);
        }
        if (index1 == 0)
        {
            for(int i = 0; i < hornUpgrades.Length; i++)
            {
                temp.Add(hornUpgrades[i]);
            }
        }
        else if(index1 == 1)
        {
            for(int i = 0; i < explosionUpgrades.Length; i++)
            {
                temp.Add(explosionUpgrades[i]);
            }
        }
        else if(index1 == 2)
        {
            for(int i = 0; i < bowUpgrades.Length; i++)
            {
                temp.Add(bowUpgrades[i]);
            }
        }

        if(index2 == 0)
        {
            for(int i = 0; i < hornUpgrades.Length; i++)
            {
                temp.Add(hornUpgrades[i]);
            }
        }
        else if(index2 == 1)
        {
            for(int i = 0; i < explosionUpgrades.Length; i++)
            {
                temp.Add(explosionUpgrades[i]);
            }
        }
        else if(index2 == 2)
        {
            for(int i = 0; i < bowUpgrades.Length; i++)
            {
                temp.Add(bowUpgrades[i]);
            }
        }
        UO.currentUpgradePool = temp.ToArray();
    }
   
    public GameObject getItem(int index)
    {
        return items[index];
    }
}
