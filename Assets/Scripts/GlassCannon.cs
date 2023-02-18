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
        pm.Damage *= damageMult;
        PactSelect.SetActive(false);
    }
}
