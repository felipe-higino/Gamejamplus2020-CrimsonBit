using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlayerController : PlayerFactory
{
    Rigidbody rb;
    public Transform cam;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update() {
        PlayerDirection();
    }
    void FixedUpdate()
    {
        MoveInput();
    }

    Vector3 initialClick, endClick;
    void MoveInput(){
        if(Input.GetMouseButtonDown(0)){
			initialClick.x = Input.mousePosition.x;
			initialClick.y = Input.mousePosition.y;
		}
		if(Input.GetMouseButton(0)){
			endClick.x += Input.mousePosition.x - initialClick.x;
			endClick.y += Input.mousePosition.y - initialClick.y;
		}else{
            endClick = Vector3.zero;
        }
        MoveTo(endClick.normalized * 2f);
    }

    void MoveTo(Vector3 direction){
        Vector3 move = transform.position + 
        (transform.forward * direction.y * speed * Time.deltaTime) + 
        (transform.right * direction.x * speed * Time.deltaTime);
        rb.MovePosition(move);
    }

    void PlayerDirection(){
        Vector3 rot = cam.eulerAngles;
		rot.x = rot.z = 0;
		transform.eulerAngles = rot;
    }
}
