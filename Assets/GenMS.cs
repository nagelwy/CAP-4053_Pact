using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GenMS : MonoBehaviour, Upgrade
{
    public int itemIndex;
    public float variable;
    public string Title;
    public string Desc;

    public void onEquip()
    {
        PlayerManager player = GameObject.Find("Player").GetComponent<PlayerManager>();
        player.MoveSpeed += variable;
    }
    public void fillUI(Text title, Text desc)
    {
        title.text = Title;
        desc.text = Desc;
    }
}
