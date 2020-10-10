using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float horSpeed;
    public bool isClimbing;

    public void setIsClimbing(bool isClimbing)
    {
        this.isClimbing = isClimbing;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        PlayerDirection();
    }
    void FixedUpdate()
    {
        if(isClimbing){
            PlayerClimbing();
        }else{
            PlayerMovement();
        }
    }
    void PlayerMovement(){
        Vector3 direction = (transform.forward * speed * Input.GetAxis("Vertical")) +
        (transform.right * speed * Input.GetAxis("Horizontal"));
        Vector3 move = rb.position + direction * Time.deltaTime;
        rb.MovePosition(move);
    }
    void PlayerClimbing(){
        Vector3 direction = (transform.forward * 1.5f * Input.GetAxis("Vertical")) +
        (transform.right * 1.5f * Input.GetAxis("Horizontal"));
        if(Input.GetButtonDown("Space")){
            rb.velocity = transform.forward * -5f + transform.up;
            isClimbing = false;
            return;
        }
        rb.velocity = transform.up + direction;
    }
    void PlayerDirection(){
        Vector3 rot = transform.eulerAngles;
        rot.y += Input.GetAxis("Mouse X") * horSpeed * Time.deltaTime;
        transform.eulerAngles = rot;
    }

}
