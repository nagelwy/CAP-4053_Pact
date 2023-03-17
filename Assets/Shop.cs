using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public PlayerManager pm;
    public Text goldtext;
    
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        goldtext.text = pm.gold.ToString();
    }
    public void onClick()
    {
        gameObject.SetActive(false);
    }
}
