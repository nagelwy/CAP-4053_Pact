using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public Shop shop;
    public int cost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if(shop.pm.gold < cost)
        {
            return;
        }
        else
        {
            shop.pm.gold -= cost;
            shop.pm.currentHealth += shop.pm.MaxHealth/2;
            if(shop.pm.currentHealth > shop.pm.MaxHealth)
            {
                shop.pm.currentHealth = shop.pm.MaxHealth;
            }
        }
    }
}
