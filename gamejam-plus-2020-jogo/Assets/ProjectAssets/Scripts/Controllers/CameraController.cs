using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : CameraFactory
{
    public float verSpeed;
    Camera cam;
    LayerMask scalable;
    PlayerController player;
    void Start()
    {
        cam = GetComponent<Camera>();
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }
    void RotateCamera(){
        Vector3 rotation = transform.eulerAngles;
        rotation.x += Input.GetAxis("Mouse Y")*-verSpeed*Time.deltaTime;

        if(rotation.x >= 180) 
            rotation.x -= 360f;
        rotation.x = Mathf.Clamp(rotation.x, -80f, 80f);
        rotation.z = 0;
        transform.eulerAngles = rotation;

    }
    void Trancking(){
        RaycastHit hit;
        bool obj = Physics.Raycast(transform.position,transform.forward,out hit,0.5f, scalable.value);
        if(obj){
            
        }
    }
}
