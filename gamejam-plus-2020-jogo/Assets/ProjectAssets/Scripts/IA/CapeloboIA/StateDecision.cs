using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDecision : MonoBehaviour
{
    [Space(32)]
    [Header("[ Decision ]")]
    [Tooltip("Thats is just a label, to help on organization.")]
    public string DecisionName;

    /* public List<StateAction> IfTrueDo, IfFalseDo;

    public void MakeDecision() {
        if(CheckCondition()){
            if(IfTrueDo != null)
                DoActions(IfTrueDo);
        }else{
            if(IfFalseDo != null)
                DoActions(IfFalseDo);
        }
    }

    void DoActions(StateAction action){
        action.DoAction();
    }

    void DoActions(List<StateAction> actions){
        foreach(StateAction action in actions)
            action.DoAction();
    } */
    [Header("Change to state: ")]
    public string IfTrue, IfFalse;

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
