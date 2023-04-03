using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeOptions : MonoBehaviour
{
    public GameObject[] currentUpgradePool;
    public Upgrade up1;
    public Text title1;
    public Text desc1;
    public Upgrade up2;
    public Text title2;
    public Text desc2;
    public Upgrade up3;
    public Text title3;
    public Text desc3;
    public void updateOptions()
    {
        for(int i = 0; i < 3; i++)
        {
            if(i == 0)
            {
                int x = Random.Range(0,currentUpgradePool.Length);
                up1 = currentUpgradePool[x].GetComponent<Upgrade>();
                up1.fillUI(title1,desc1);
            }
            else if(i == 1)
            {
                int x = Random.Range(0,currentUpgradePool.Length);
                up2 = currentUpgradePool[x].GetComponent<Upgrade>();
                up2.fillUI(title2,desc2);
            }
            else if(i == 2)
            {
                int x = Random.Range(0,currentUpgradePool.Length);
                up3 = currentUpgradePool[x].GetComponent<Upgrade>();
                up3.fillUI(title3,desc3);
            }
        }
    }
    public void clicked(int index)
    {
        if(index == 0)
        {
            up1.onEquip();
        }
        else if(index == 1)
        {
            up2.onEquip();
        }
        else if(index == 2)
        {
            up3.onEquip();
        }
        gameObject.SetActive(false);
    }
}
