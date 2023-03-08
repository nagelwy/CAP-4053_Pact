using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlassCannon : MonoBehaviour, Pact
{
    public GameObject PactSelect;
    public Text Title;
    public Text Desc;
    public Button button;
    public string titleString;
    public string descString;
    private PlayerManager pm;
    public float healthDivide;
    public float damageMult;
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
        pm.MaxHealth /= healthDivide;
        pm.currentHealth = pm.MaxHealth;
        pm.Damage *= damageMult;
        pm.pact = this;
    }
    public Sprite getIcon()
    {
        return icon;
    }
}
