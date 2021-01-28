using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#region Classes Rotuladas
[System.Serializable]
public struct StateDecisions
{
    [SerializeField]string DecisionName;
    [SerializeField]public StateDecision decision;
}
#endregion

[System.Serializable]
public class StateAI: MonoBehaviour
{
    
    [Tooltip("Is the name of state, the use this for search the next state that need to execute.")]
    [SerializeField]public string stateName;

    string newState;

    public UnityEvent doActions;

    [LabelByChild("DecisionName")]
    [ReorderableList(ListStyle.Round)]
    [SerializeField]public List<StateDecisions> decisions;

    public string RunState()
    {
        doActions?.Invoke();

        newState = MakeDecisions(decisions);

        //Repeat the Same State
        if(newState == null || newState == "" || newState.Length < 1)
            newState = stateName;

        return newState;
    }

    string MakeDecisions(List<StateDecisions> decisions){
        string state = "";
        foreach(StateDecisions Decision in decisions){
            state = Decision.decision.MakeDecision();
            if(state != "" && state != null)
                return state;
        }
        return state;
    }

}
