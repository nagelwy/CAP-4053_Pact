using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    SelectionManager gsm;
    Item i;

    // Start is called before the first frame update
    void Start()
    {
        gsm = GameObject.Find("GameStartManager").GetComponent<SelectionManager>();
        i = gameObject.GetComponentInParent<Item>();
        Debug.Log(i);
    }

    public void OnClick()
    {
        gameObject.GetComponent<Animator>().SetTrigger("In");
        gsm.clickedObjs++;
    }
    public void endScroll()
    {
        i.UpdateStats();
        gsm.onClick();

    }
}
