using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Item
{
    
    public void onUse()
    {
        //this will be called when the ability of the item is used.
    }
    public void displayInfo()
    {
        
    }
    public void onSelect()
    {

    }
    public void UpdateStats()
    {
        
    }
    public Sprite getIcon()
    {
        return null;
    }
}
