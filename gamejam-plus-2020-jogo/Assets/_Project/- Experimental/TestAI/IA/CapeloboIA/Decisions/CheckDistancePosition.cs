using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistancePosition : StateDecision
{
    
    [BeginGroup("Specific Parameters:")]
    [Tooltip("[Transform] Target is the object used to chech the distance")]

    [SerializeField]
    private Transform target;
    public ComparisionMode condition;
    
    [Tooltip("[Float] The parameter used on comparision."),EndGroup]
    public float distance;

    public override bool CheckCondition()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(target == null){
            Debug.Log("Target is NULL");
            return false;
        }

        if(condition == ComparisionMode.BiggerOrEqual)
            return distance >= this.distance;

        if(condition == ComparisionMode.LessOrEqual)
            return distance <= this.distance;

        if(condition == ComparisionMode.BiggerThen)
            return distance > this.distance;

        if(condition == ComparisionMode.LessThan)
            return distance < this.distance;

        if(condition == ComparisionMode.Equals)
            return distance == this.distance;

        if(condition == ComparisionMode.Different)
            return distance != this.distance;
        
        return false;

    }

  
}
