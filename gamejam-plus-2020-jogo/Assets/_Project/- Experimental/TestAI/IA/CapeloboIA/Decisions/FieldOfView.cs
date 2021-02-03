using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : StateDecision
{
    [BeginGroup("Specific Parameters:")]
    [SerializeField]float radiusOfView;
    [SerializeField,Range(0f,1f)]float angleRange;
    //[SerializeField] LayerMask targetLayer;
    [SerializeField]Transform head;
    [EndGroup]
    [SerializeField]Transform target;

    public override bool CheckCondition(){
        Vector3 targetDirection = target.position - head.position;
        float direction = Vector3.Dot(targetDirection.normalized,head.forward);
        RaycastHit hit;
        
        bool onView = Physics.Raycast(head.position,targetDirection.normalized,out hit,radiusOfView) && direction > angleRange;
        
        if(hit.transform != null)
            return onView && hit.transform.Equals(target);
        else
            return false;

    }

}
