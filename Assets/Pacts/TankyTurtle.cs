using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankyTurtle : MonoBehaviour, Pact
{
    public GameObject PactSelect;
    public Text Title;
    public Text Desc;
    public Button button;
    public string titleString;
    public string descString;
    private PlayerManager pm;
    public float healthMult;
    public float attackSpeedDiv;
    public float moveSpeedDiv;
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
        pm.MaxHealth *= healthMult;
        pm.currentHealth = pm.MaxHealth;
        pm.AttackTime *= attackSpeedDiv;
        pm.MoveSpeed /= moveSpeedDiv;
        pm.pact = this;
    }
    public Sprite getIcon()
    {
        return icon;
    }
}
