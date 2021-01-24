using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPosition : StateDecision
{
    public MoveToPosition lastPosition;

    public override bool CheckCondition(){
        return Vector3.Distance(transform.position, lastPosition.getDestination()) > 1.5f;
    }
}
