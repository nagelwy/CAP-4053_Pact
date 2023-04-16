using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePotion : MonoBehaviour
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
            shop.pm.Damage += 2;
        }
    }
}
