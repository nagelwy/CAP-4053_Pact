using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Slider slider;
    public PlayerManager pm;

    void Start()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerManager>();
    }
    void Update()
    {
        slider.value = pm.xp;
        slider.maxValue = pm.xpToLevel;
    }
}
