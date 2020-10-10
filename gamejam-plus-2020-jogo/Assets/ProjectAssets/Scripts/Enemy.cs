using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerController player;
    public float speed;
    Rigidbody rb;
    public Transform head;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(RangeOfViewInArea(15f,0.85f))
            RotateToPlayer();
    }

    void RotateToPlayer(){
        transform.LookAt(player.transform);
        Vector3 rot = transform.eulerAngles;
        rot.x = 0f;
        rot.z = 0f;
            transform.eulerAngles = rot;
        
        Vector3 move = rb.position + transform.forward *speed *Time.deltaTime;
        rb.MovePosition(move);
    }



    bool RangeOfViewInArea(float distance, float range)
	{
		RaycastHit hit;
		float direction = Vector3.Dot((player.transform.position - transform.position).normalized , transform.forward);
		if(Vector3.Distance(transform.position,player.transform.position) < distance)
		if(Physics.Linecast(head.position, player.transform.position, out hit) && direction > range){
			return hit.transform.Equals(player.transform);
		}
		return false;
	}
}
