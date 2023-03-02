using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    SelectionManager gsm;
    // Start is called before the first frame update
    void Start()
    {
        gsm = GameObject.Find("GameStartManager").GetComponent<SelectionManager>();
    }

    public void OnClick()
    {
        gameObject.GetComponent<Animator>().SetTrigger("In");
    }
    public void endScroll()
    {
        gsm.onClick();
    }
}
