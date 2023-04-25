using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicMan : MonoBehaviour, Pact
{
    public GameObject PactSelect;
    public Text Title;
    public Text Desc;
    public Button button;
    public string titleString;
    public string descString;
    private PlayerManager pm;
    public float abilityCDMult;
    public float attackSpeedDiv;

    public Sprite icon;

    void Start()
    {
        displayInfo();
    }
    public void displayInfo()
    {
        Title.text = titleString;
        Desc.text = descString;
    }
    public void UpdateStats()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerManager>();
        pm.abilitydivnum = abilityCDMult;
        pm.AttackTime *=attackSpeedDiv;
        pm.pact = this;
    }
    public Sprite getIcon()
    {
        return icon;
    }
}
