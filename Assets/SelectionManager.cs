using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectionManager : MonoBehaviour
{
    public GameObject ItemSelect;
    public GameObject PactSelect;
    public GameObject Bar;
    public Button[] buttons;
    public int phaseCounter = 0;
    private PlayerManager pm;
    public GameObject icons;
    public int clickedObjs;
    // Start is called before the first frame update
    void Start()
    {
        ItemSelect.SetActive(true);
        pm = GameObject.Find("Player").GetComponent<PlayerManager>();
    }
    public void onClick()
    {
        if(phaseCounter == 0)
        {
            // refresh items in the item select
            phaseCounter++;
        }
        else if(phaseCounter == 1)
        {
            ItemSelect.SetActive(false);
            PactSelect.SetActive(true);
            phaseCounter++;
        }
        else
        {
            PactSelect.SetActive(false);
            icons.SetActive(true);
            pm.UpdateIcons();
            Bar.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(clickedObjs == 2)
        {
            foreach(Button b in buttons)
            {
                b.interactable = false;
            }
        }
    }
}
