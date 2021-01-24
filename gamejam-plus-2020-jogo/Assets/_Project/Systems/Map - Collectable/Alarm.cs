using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    Transform enemy;
    //public Transform[] pos;
    public float minDist;

    private void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("Player")){
        enemy = GameObject.FindObjectOfType<Enemy>().transform;
            if(Vector3.Distance(other.transform.position, enemy.position) > minDist){
                int sort = Random.Range(1,4);
                Vector3 newPos = other.transform.position;
                if(sort==1){
                    newPos = newPos + other.transform.right * minDist;
                }
                if(sort==2){
                    newPos = newPos + other.transform.right * -minDist;
                }
                if(sort==3){
                    newPos = newPos + other.transform.forward * -minDist;
                }
                enemy.position = newPos;
            }
        }
    }

}
