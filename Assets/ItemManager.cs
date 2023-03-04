using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] items;

    public void updateStat(int index)
    {
        items[index].GetComponent<Item>().UpdateStats();
    }
}
