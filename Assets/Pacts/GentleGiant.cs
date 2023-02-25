using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GentleGiant : MonoBehaviour, Pact
{
    public GameObject PactSelect;
    public Text Title;
    public Text Desc;
    public Button button;
    public string titleString;
    public string descString;
    private PlayerManager playerManager;
    public float healthMult;
    public float damageDiv;
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
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        playerManager.MaxHealth *= healthMult;
        playerManager.Damage /= damageDiv;
        playerManager.pact = this;
    }
    public Sprite getIcon()
    {
        return icon;
    }
}
