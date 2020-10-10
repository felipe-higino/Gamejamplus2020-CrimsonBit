using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int numberOfRooms;
    public GameObject roomPrefab;
    public Transform roomStartPosition;
    public static RoomManager instance;
    int roomNumber;
    List<GameObject> rooms;

    void Awake(){
        instance = this;
    }

    void Start(){
        rooms = new List<GameObject>();
        GenerateRooms();
    }

    /* public void GenerateRooms(){
        Instantiate(roomPrefab,roomStartPosition.position,Quaternion.identity);
    } */
    int lastDir = 0;
    public void GenerateRooms(){
        //Creation of first room
        GameObject newRoom;
        newRoom = Instantiate(roomPrefab,roomStartPosition.position,Quaternion.identity);
        newRoom.name = newRoom.name +" "+(roomNumber+1);
        Room roomScript = newRoom.GetComponent<Room>();
        rooms.Add(newRoom);

        //Creation of some rooms - setting positions
        for(roomNumber = 1; roomNumber < numberOfRooms; roomNumber++){
            int dir = roomScript.SortDirection(lastDir);
            Vector3 nextRoomPosition = roomScript.directions[dir].position;
            lastDir = dir;

            newRoom = Instantiate(roomPrefab,nextRoomPosition,Quaternion.identity);
            newRoom.name = newRoom.name +" "+(roomNumber+1);
            rooms.Add(newRoom);
            roomScript = newRoom.GetComponent<Room>();
        }

        //Creation of walls of rooms
        foreach(GameObject currentRoom in rooms){
            roomScript = currentRoom.GetComponent<Room>();
            Transform[] direction = roomScript.directions;
            GameObject[] walls = roomScript.Walls;
            for(int i = 0; i < walls.Length; i++){
                if(
                    Physics.Linecast(currentRoom.transform.position, direction[i].position)
                ){
                    continue;
                }else{
                    walls[i].SetActive(true);
                }
            }
        }
    }

    public void GenerateSpiralRooms(){
        //Creation of first room
        GameObject newRoom;
        newRoom = Instantiate(roomPrefab,roomStartPosition.position,Quaternion.identity);
        newRoom.name = newRoom.name +" "+(roomNumber+1);
        Room roomScript = newRoom.GetComponent<Room>();
        rooms.Add(newRoom);

        //Creation of some rooms - setting positions
        for(roomNumber = 1; roomNumber < numberOfRooms; roomNumber++){
            int dir = roomScript.SortDirection();
            Vector3 nextRoomPosition = roomScript.directions[dir].position;
            newRoom = Instantiate(roomPrefab,nextRoomPosition,Quaternion.identity);
            newRoom.name = newRoom.name +" "+(roomNumber+1);
            rooms.Add(newRoom);
            roomScript = newRoom.GetComponent<Room>();
        }

        //Creation of walls of rooms
        foreach(GameObject currentRoom in rooms){
            roomScript = currentRoom.GetComponent<Room>();
            Transform[] direction = roomScript.directions;
            GameObject[] walls = roomScript.Walls;
            for(int i = 0; i < walls.Length; i++){
                if(
                    Physics.Linecast(currentRoom.transform.position, direction[i].position)
                ){
                    continue;
                }else{
                    walls[i].SetActive(true);
                }
            }
        }
    }

    public void Increase(){
        roomNumber++;
    }

    public bool IsFirstRoom
    {
        get {
            return numberOfRooms == 0;
        }
    }

     public bool IsLastRoom
    {
        get {
            return numberOfRooms == roomNumber;
        }
    }

}
