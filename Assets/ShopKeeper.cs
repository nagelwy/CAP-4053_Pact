using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public GameObject shop;
    public GameObject popup;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(shop == null)
        {
            shop = GameObject.Find("RoomSpawnManager").GetComponent<FloorGenerator>().ShopUI;
        }
    }
     void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            popup.SetActive(true);
            if(Input.GetKey("f"))
            {
                shop.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            popup.SetActive(false);
        }
    }
}
