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
    }

    public override void DoAction()
    {
        GoToPoint();
    }

    Vector3 destination;

    public Vector3 getDestination()
    {
        return this.destination;
    }

    public void setDestination(Vector3 destination)
    {
        this.destination = destination;
    }

    public void GoToPoint(){
        Debug.Log("Going to Position");
        /* Vector3 pos = transform.position;
        pos += destination * velocity * Time.deltaTime;
        rb.MovePosition(pos); */
    }


}
