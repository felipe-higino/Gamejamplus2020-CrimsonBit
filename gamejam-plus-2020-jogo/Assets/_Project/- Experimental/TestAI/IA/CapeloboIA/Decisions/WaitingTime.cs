using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingTime : StateDecision
{
    float timeForSeconds;

    public void SetTime(float waitingTime){
        timeForSeconds = waitingTime;
    }

    public override bool CheckCondition(){
        timeForSeconds -= Time.deltaTime;
        return timeForSeconds <= 0;
    }

 
}
