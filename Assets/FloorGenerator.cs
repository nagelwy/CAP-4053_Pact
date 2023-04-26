using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public GameObject[] floor1Rooms;
    public GameObject[] floor1Bosses;
    public GameObject[] floor2Rooms;
    public GameObject[] floor2Bosses;
    public GameObject[] floor3Rooms;
    public GameObject[] floor3Bosses;
    public GameObject shopRoom;
    public int floorIndex;
    public int floor1Size;
    public int floor2Size;
    public int floor3Size;
    public Room spawnRoom;
    public List<GameObject> spawnedRooms;
    public Room currentRoom;
    public GameObject ShopUI; 
    public GameObject endScreen;
    
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
            spawnedRooms.Add(nextRoom);
            currentRoom = nextRoom.GetComponent<Room>();
        }
        //spawn shop
        GameObject shop = Instantiate(shopRoom, currentRoom.exitPoint.transform.position-shopRoom.GetComponent<Room>().enterPoint.transform.position,Quaternion.identity);
        currentRoom = shop.GetComponent<Room>();
        spawnedRooms.Add(shop);
        //spawn boss
        int y = Random.Range(0,floor1Bosses.Length);
        GameObject bossRoom = Instantiate(floor1Bosses[y], currentRoom.exitPoint.transform.position-floor1Bosses[y].GetComponent<Room>().enterPoint.transform.position,Quaternion.identity);
        currentRoom = bossRoom.GetComponent<Room>();
        spawnedRooms.Add(bossRoom);
        AstarPath.active.Scan();
    }
    public void SpawnFloor2()
    {
        for(int i = 0; i < floor2Size; i++)
        {
            int x = Random.Range(0,floor2Rooms.Length);
            GameObject nextRoom = Instantiate(floor2Rooms[x], currentRoom.exitPoint.transform.position-floor2Rooms[x].GetComponent<Room>().enterPoint.transform.position,Quaternion.identity);
            spawnedRooms.Add(nextRoom);
            currentRoom = nextRoom.GetComponent<Room>();
        }
        //spawn shop
        GameObject shop = Instantiate(shopRoom, currentRoom.exitPoint.transform.position-shopRoom.GetComponent<Room>().enterPoint.transform.position,Quaternion.identity);
        currentRoom = shop.GetComponent<Room>();
        spawnedRooms.Add(shop);
        //spawn boss
        int y = Random.Range(0,floor2Bosses.Length);
        GameObject bossRoom = Instantiate(floor2Bosses[y], currentRoom.exitPoint.transform.position-floor2Bosses[y].GetComponent<Room>().enterPoint.transform.position,Quaternion.identity);
        currentRoom = bossRoom.GetComponent<Room>();
        spawnedRooms.Add(bossRoom);
        AstarPath.active.Scan();
    }

    public void SpawnFloor3()
    {
        for(int i = 0; i < floor3Size; i++)
        {
            int x = Random.Range(0,floor3Rooms.Length);
            GameObject nextRoom = Instantiate(floor3Rooms[x], currentRoom.exitPoint.transform.position-floor3Rooms[x].GetComponent<Room>().enterPoint.transform.position,Quaternion.identity);
            spawnedRooms.Add(nextRoom);
            currentRoom = nextRoom.GetComponent<Room>();
        }
        //spawn shop
        GameObject shop = Instantiate(shopRoom, currentRoom.exitPoint.transform.position-shopRoom.GetComponent<Room>().enterPoint.transform.position,Quaternion.identity);
        currentRoom = shop.GetComponent<Room>();
        spawnedRooms.Add(shop);
        //spawn boss
        int y = Random.Range(0,floor3Bosses.Length);
        GameObject bossRoom = Instantiate(floor3Bosses[y], currentRoom.exitPoint.transform.position-floor3Bosses[y].GetComponent<Room>().enterPoint.transform.position,Quaternion.identity);
        currentRoom = bossRoom.GetComponent<Room>();
        spawnedRooms.Add(bossRoom);
        AstarPath.active.Scan();
    }

    public void unspawn()
    {
        GameObject.Find("Player").transform.position = new Vector3(-85,-2,0);
        foreach(GameObject g in spawnedRooms)
        {
            Destroy(g);
        }
        currentRoom = spawnRoom;

        if(floorIndex == 0)
        {
            floorIndex++;
            SpawnFloor2();
        }

        else if(floorIndex == 1)
        {
            floorIndex++;
            SpawnFloor3();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void endgame()
    {
        endScreen.SetActive(true);
    }
}
