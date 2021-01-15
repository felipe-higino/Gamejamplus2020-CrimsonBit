using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindInRadius : StateDecision
{
    public LayerMask layers;

    public float Radius;

    [HideInInspector]
    public Transform objectFinded;
    public bool FindObject(){
        Collider[] obj = Physics.OverlapSphere(transform.position,Radius,layers);
        if(obj.Length < 1) return false;
        objectFinded = obj[0].transform;
        return true;
    }
}
