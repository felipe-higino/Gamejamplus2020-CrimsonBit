using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : StateAction
{
    Rigidbody rb;
    
    [Tooltip("The velocity of this object gonna move to position.")]
    public float velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        destination = transform.position;
    }

    Vector3 destination;

    public Vector3 getDestination()
    {
        return this.destination;
    }

    public void getDestination(FindInRadius location)
    {
        this.destination = location.objectFinded.position;
    }

    public void setDestination(Vector3 destination)
    {
        this.destination = destination;
    }
    Transform targetDestination;

     public void GetTarget(Transform destiny){
        setDestination(destiny.position);
        GoToPoint();
    }


    public void GoToPoint(){
        transform.LookAt(destination);
        CorrectRotation();
        Vector3 pos = transform.position + transform.forward * velocity * Time.deltaTime;
        rb.MovePosition(pos);
    }

    public void GoAwayFromPoint(){
        transform.LookAt(destination);
        CorrectRotation();
        Vector3 pos = transform.position - transform.forward * velocity * Time.deltaTime;
        rb.MovePosition(pos);
    }

    void CorrectRotation(){
        Vector3 rot = transform.eulerAngles;
        rot.x = rot.z = 0f;
        transform.eulerAngles = rot;
    }


}
