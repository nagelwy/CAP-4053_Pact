using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public int index;
    ItemManager im;
    SelectionManager gsm;

    // Start is called before the first frame update
    void Start()
    {
        gsm = GameObject.Find("GameStartManager").GetComponent<SelectionManager>();
        im = GameObject.Find("ItemManager").GetComponent<ItemManager>();
    }

    public void OnClick()
    {
        gameObject.GetComponent<Animator>().SetTrigger("In");
        gsm.clickedObjs++;
    }
    public void endScroll()
    {
        im.updateStat(index);
        gsm.onClick();

    }
}
