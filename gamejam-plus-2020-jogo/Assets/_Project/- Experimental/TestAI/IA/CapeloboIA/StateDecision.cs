using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateDecision : MonoBehaviour
{
    [Header("[ Decision ]")]
    [Tooltip("Thats is just a label, to help on organization.")]
    public string DecisionName;
    
    [BeginGroup("Conditions:")]
    
    [Header("Change to state: ")]
    public string IfTrue;

    [EndGroup]
    [Header("Change to state: ")]
    public string  IfFalse;

    
  




    public string MakeDecision(){
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
