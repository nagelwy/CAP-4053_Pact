using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public GameObject[] floor1Rooms;
    public GameObject[] floor1Bosses;
    public GameObject shopRoom;
    public int floor1Size;
    public Room currentRoom;
    public GameObject ShopUI; 
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnFloor1();
    }
    public void SpawnFloor1()
    {
        for(int i = 0; i < floor1Size; i++)
        {
            int x = Random.Range(0,floor1Rooms.Length);
            GameObject nextRoom = Instantiate(floor1Rooms[x], currentRoom.exitPoint.transform.position-floor1Rooms[x].GetComponent<Room>().enterPoint.transform.position,Quaternion.identity);
            currentRoom = nextRoom.GetComponent<Room>();
        }
        //spawn shop
        GameObject shop = Instantiate(shopRoom, currentRoom.exitPoint.transform.position-shopRoom.GetComponent<Room>().enterPoint.transform.position,Quaternion.identity);
        currentRoom = shop.GetComponent<Room>();

        //spawn boss
        int y = Random.Range(0,floor1Bosses.Length);
        GameObject bossRoom = Instantiate(floor1Bosses[y], currentRoom.exitPoint.transform.position-floor1Bosses[y].GetComponent<Room>().enterPoint.transform.position,Quaternion.identity);
        currentRoom = bossRoom.GetComponent<Room>();
        AstarPath.active.Scan();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
