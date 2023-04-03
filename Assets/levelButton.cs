using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelButton : MonoBehaviour
{
    public int numOfUpgrades;
    public GameObject upgradeChoices;
    
    public void onClick()
    {
        numOfUpgrades--;
        upgradeChoices.SetActive(true);
        upgradeChoices.GetComponent<UpgradeOptions>().updateOptions();
        if(numOfUpgrades == 0)
        {
            gameObject.SetActive(false);
        }

    }
}
