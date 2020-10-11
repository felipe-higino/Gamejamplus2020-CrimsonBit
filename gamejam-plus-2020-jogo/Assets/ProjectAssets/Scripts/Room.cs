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
            
            for(int i = 0; i < directions.Length; i++){
                if(
                    Physics.Linecast(transform.position,directions[i].position,out hit)
                    && hit.transform.GetComponent<Room>() != null
                )
                    continue;
                else{
                    openDirection = i;
                    return;
                }
            }
        }

    }
    
}
