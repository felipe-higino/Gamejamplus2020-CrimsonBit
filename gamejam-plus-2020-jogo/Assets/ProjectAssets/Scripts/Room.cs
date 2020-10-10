using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Walls;
    [SerializeField]
    public Transform[] directions;
    [SerializeField]
    public GameObject[] Decorations;

    public int openDirection = -1;

/* 
    void Start()
    {

        if(RoomManager.instance!=null){
            if(RoomManager.instance.IsFirstRoom){
                openDirection = 2;
            }  
        }

        //Sort the direction of new room
        if(openDirection == -1)
        openDirection = (int) Random.Range(0,directions.Length);
        
        Collider[] cols = Physics.OverlapSphere(directions[openDirection].position,1f);
        foreach(Collider c in cols){
            if(c.GetComponent<Room>() != null){
                if(openDirection == 0) openDirection = 1;
                else if(openDirection == directions.Length) openDirection = 2;
                else openDirection--;
            }
        }

        //Begin the check
        for(int i = 0; i < directions.Length;i++){
            
            if(i != openDirection)//If isnt the direction of new room, create walls. If is, do nothing.
            {
                RaycastHit hit;
                //Check if exist something between that room and the checked direction 
                 if(Physics.Linecast(transform.position,directions[i].position, out hit)){
                    //if(Random.Range(0,2) == 0)//if exists, choose if the object(wall) wanna be destroyed or not.
                        Walls[i].SetActive(false);
                }else
                    Walls[i].SetActive(true);//If is empty, create the wall.
                
            }
        }

        if(RoomManager.instance.IsLastRoom){
            Walls[openDirection].SetActive(true);
            return;
        }

        //Create new room on design direction
        if(room != null)
            Instantiate(room,directions[openDirection].position,Quaternion.identity);
        //Create the plataforms of this room

        RoomManager.instance.Increase();
    }
 */

    public int SortDirection(){
        //Sort the direction of new room
        openDirection = (int) Random.Range(0,directions.Length);
        //If the direction is the position of last room, sort again.
        CheckSelectedDirection(openDirection);
        //If not, return the direction.
        return openDirection;
    }

    public int SortDirection(int lastDir){
        //Sort the direction of new room
        openDirection = (int) Random.Range(0,directions.Length);
        if(openDirection == lastDir){
            openDirection++;
            if(openDirection > directions.Length-1)
                openDirection = 0;
        }
        //If the direction is the position of last room, sort again.
        CheckSelectedDirection(openDirection);
        //If not, return the direction.
        return openDirection;
    }



    //public int CheckSelectedDirection(int sorted){
    public void CheckSelectedDirection(int sorted){
        RaycastHit hit;
        if(
            Physics.Linecast(transform.position,directions[openDirection].position,out hit)
            && hit.transform.GetComponent<Room>() != null
        ){
            Debug.Log(transform.name +" encontrou a sala "+ hit.transform.name);
            for(int i = 0; i < directions.Length; i++){
                if(
                    Physics.Linecast(transform.position,directions[i].position,out hit)
                    && hit.transform.GetComponent<Room>() != null
                )
                    Debug.Log(transform.name +" encotrou a sala "+ hit.transform.name);
                else{
                    openDirection = i;
                    return;
                }
            }
        }

    }

    public void CheckRight(){
        RaycastHit hit;
        if(
            Physics.Linecast(transform.position,directions[openDirection].position,out hit)
            && hit.transform.GetComponent<Room>() != null
        ){
            Debug.Log(transform.name +" encontrou a sala "+ hit.transform.name);
            for(int i = 0; i < directions.Length; i++){
                if(
                    Physics.Linecast(transform.position,directions[i].position,out hit)
                    && hit.transform.GetComponent<Room>() != null
                )
                    Debug.Log(transform.name +" encotrou a sala "+ hit.transform.name);
                else{
                    openDirection = i;
                    return;
                }
            }
        }

    }
    
}
