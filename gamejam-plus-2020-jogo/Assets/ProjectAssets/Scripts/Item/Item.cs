using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player, enemy;
    public float minDist;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().transform;
        enemy = GameObject.FindObjectOfType<Enemy>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("Player")){
            GameLoopManager.instance.RemoveItem(transform.parent.gameObject);
            
            if(Vector3.Distance(enemy.position, player.position) > minDist){
                int sort = Random.Range(1,4);
                Vector3 newPos = other.transform.position;
                if(sort==1){
                    newPos = newPos + other.transform.right * minDist;
                    enemy.position = newPos;
                }
                if(sort==2){
                    newPos = newPos + other.transform.right * -minDist;
                    enemy.position = newPos;
                }
                if(sort==3){
                    newPos = newPos + other.transform.forward * -minDist;
                    enemy.position = newPos;
                }
                transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
