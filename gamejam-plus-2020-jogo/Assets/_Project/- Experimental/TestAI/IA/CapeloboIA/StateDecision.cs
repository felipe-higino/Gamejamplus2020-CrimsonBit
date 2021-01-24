﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateDecision : MonoBehaviour
{
    [Space(32)]
    [Header("[ Decision ]")]
    [Tooltip("Thats is just a label, to help on organization.")]
    public string DecisionName;
    
    [Header("Change to state: ")]
    public string IfTrue, IfFalse;

    public string MakeDecision(){
        Debug.Log("Decision: "+DecisionName);
        if(CheckCondition()){
            return IfTrue;
        }else{
            return IfFalse;
        }
    }

    public virtual bool CheckCondition(){
        return true;
    }

    
    
}