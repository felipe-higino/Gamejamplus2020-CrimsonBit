using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAI : MonoBehaviour
{

    [Space(32)]
    [Header("[ State AI ]")]
    [Tooltip("Is the name of state, the use this for search the next state that need to execute.")]
    public string stateName;

    public List<StateAction> actions;
    public List<StateDecision> decisions;

    string newState;

    // Update is called once per frame
    public string RunState()
    {
        DoActions(actions);

        newState = MakeDecisions(decisions);

        //Repeat the Same State
        if(newState == null || newState == "" || newState.Length < 1)
            newState = stateName;

        return newState;
    }
     void DoActions(List<StateAction> actions){
        foreach(StateAction action in actions)
            action.DoAction();
    }
    string MakeDecisions(List<StateDecision> decisions){
        string state = "";
        foreach(StateDecision decision in decisions){
            state = decision.MakeDecision();
            if(state != "")
                return state;
        }
        return state;
    }

    // fazer um dicionario no brain <string nameState, StateAI> e fazer ele percorrer esse dicionario rodar cada estado
}
