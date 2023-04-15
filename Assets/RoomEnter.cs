using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnter : MonoBehaviour
{
    public GameObject[] doors;
    public bool bossRoom;
    public Boss b;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool enemiesAlive = false;
        foreach(GameObject enemy in enemies)
        {
            if( enemy != null)
            {
                enemiesAlive = true;
            }
        }
        if(!enemiesAlive)
        {
            foreach(GameObject d in doors)
            {
                d.SetActive(false);
            }
            if(bossRoom)
            {
                GameObject.Find("RoomSpawnManager").GetComponent<FloorGenerator>().unspawn();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            foreach(GameObject d in doors)
            {
                d.SetActive(true);
                if(bossRoom)
                {
                    b.onEnter();
                }
            }
        }
    }
}
