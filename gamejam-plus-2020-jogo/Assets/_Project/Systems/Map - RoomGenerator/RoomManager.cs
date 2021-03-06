﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int numberOfRooms;
    public GameObject roomPrefab;
    public Transform roomStartPosition;
    public static RoomManager instance;
    public GameObject player, monster;
    public int itemQuantity;
    public GameObject item, goal;
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
        int playerRoom, monsterRoom;
        playerRoom = (numberOfRooms/4);
        monsterRoom = ((numberOfRooms/4)*2);
        //itemQuantity = numberOfRooms/itemQuantity;

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


        int index = 0;
        //Creation of walls of rooms, decorations
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
            roomScript.CreateDecoration();

            if(index == playerRoom){
                Instantiate(player, currentRoom.transform.position, Quaternion.identity);
            }
            if(index == monsterRoom){
                Instantiate(monster, currentRoom.transform.position, Quaternion.identity);
            }

            if(index%itemQuantity == 0){
                GameObject newItem = Instantiate(item,currentRoom.transform.position,Quaternion.identity);
                GameLoopManager.instance.AddItem(newItem);
            }
            index++;

        }


        GameObject obj = Instantiate(goal, rooms[(rooms.Count/2)].transform.position, Quaternion.identity);
        GameLoopManager.instance.setGoal(obj);
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
