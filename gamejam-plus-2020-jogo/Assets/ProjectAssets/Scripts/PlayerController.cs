using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    float run;
    public float horSpeed;
    public bool isClimbing;
    public Transform foot;

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
        PlayerRun();
    }
    void FixedUpdate()
    {
        if(isClimbing){
            PlayerClimbing();
        }else{
            PlayerMovement();
            PlayerJump();
        }
    }
    void PlayerMovement(){
        Vector3 direction = (transform.forward * speed*run * Input.GetAxis("Vertical")) +
        (transform.right * speed*run * Input.GetAxis("Horizontal"));
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
    void PlayerRun(){
        if(Input.GetKey(KeyCode.LeftShift))
            run = 2f;
        else
            run = 1f;
    }
    void PlayerJump(){
        if(Physics.Raycast(foot.position, -transform.up,0.25f))
        if(Input.GetKey(KeyCode.Space))
            rb.velocity = transform.up * 5f;
    }

}
