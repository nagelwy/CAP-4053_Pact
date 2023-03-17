using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayerManager pm;

    void Start()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerManager>();
    }
    void Update()
    {
        slider.maxValue = pm.MaxHealth;
        slider.value = pm.currentHealth;
    }
    /*public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    

    public void setHealth(float health)
    {
        slider.value = health;
    }*/
}
