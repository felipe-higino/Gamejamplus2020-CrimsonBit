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
public class StateAI
{
    
    [Tooltip("Is the name of state, the use this for search the next state that need to execute.")]
    [SerializeField]public string name;

    string newState;

    public UnityEvent doActions;

    [SerializeField]public List<StateDecisions> decisions;

    public string RunState()
    {
        doActions?.Invoke();

        newState = MakeDecisions(decisions);
        
        //Repeat the Same State
        bool emptyState = (newState == null || newState == "" || newState.Length < 1);
        if(emptyState)
            newState = name;

        return newState;
    }

    [HideInInspector]
    public string currentDecision;
    string MakeDecisions(List<StateDecisions> decisions){
        string state = "";
        foreach(StateDecisions Decision in decisions){
            state = Decision.decision.MakeDecision();
            currentDecision = Decision.decision.DecisionName;
            bool isValid = (state != "" && state != null);
            if(isValid)
                return state;
        }
        return state;
    }

}
