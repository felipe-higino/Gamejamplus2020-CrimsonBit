using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPosition : StateDecision
{
    [BeginGroup("Specific Parameters:"),EndGroup]
    public CapeloboActions lastPosition;

    public override bool CheckCondition(){
        return (transform.position - lastPosition.getDestination()).magnitude > 1.5f;
    }
}
