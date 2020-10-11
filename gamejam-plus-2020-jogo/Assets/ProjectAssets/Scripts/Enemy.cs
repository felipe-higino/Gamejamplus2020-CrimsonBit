﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerController player;
    public float speed;
    Rigidbody rb;
    public Transform head;
    public float distance;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    bool getPlayer;
    void Update() {
        HuntPlayer();
        RotateToPlayer(
            IsNearby() ||
            RangeOfViewInArea(distance*1.5f,1f) ||
            getPlayer
        );
    }


    void FixedUpdate()
    {
        
        MoveToPlayer();
    }
    float time = 0;
    public float TimeToHunt;
    void HuntPlayer(){
        if(time >= TimeToHunt){
            getPlayer = !getPlayer;
            if(getPlayer)
                time = TimeToHunt/2;
            else
                time = 0f;
        }else{
            time += Time.deltaTime;
        }
    }

    void RotateToPlayer(bool nearby){
        head.LookAt(player.transform);
        Vector3 rot = head.eulerAngles;
        rot.x = 0f;
        rot.z = 0f;
        if(nearby)
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.Euler(new Vector3(0,rot.y,0)),
                0.05f
            );
        else{
            rot.y +=45f;
            transform.eulerAngles = rot;
        }

    }
    void MoveToPlayer(){
        Vector3 move = rb.position + transform.forward *speed*Time.deltaTime;
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
    bool IsNearby()
	{
		return Vector3.Distance(transform.position,player.transform.position) < distance &&
        transform.position.y - player.transform.position.y < 6f;
	}
}
