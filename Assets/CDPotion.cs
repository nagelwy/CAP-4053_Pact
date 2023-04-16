using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDPotion : MonoBehaviour
{
    public Shop shop;
    public int cost;
    public Bow b;
    public HornOfTheMinotaur h;
    public Explosion e;
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
            b.CD *= 0.8f;
            h.CD *= 0.8f;
            e.CD *= 0.8f;
        }
    }
}
