using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateAI : MonoBehaviour
{
    [Header("[ State AI ]")]
    [Tooltip("Is the name of state, the use this for search the next state that need to execute.")]
    [SerializeField]public string stateName;

    string newState;
    

    #region Classes Rotuladas
    [System.Serializable]
    public struct StateActions
    {
        [SerializeField]string ActionName;
        [SerializeField]public StateAction action;
    }

    [System.Serializable]
    public struct StateDecisions
    {
        [SerializeField]string DecisionName;
        [SerializeField]public StateDecision decision;
    }
    #endregion

    [ReorderableList(ListStyle.Round)]
    [LabelByChild("ActionName")]
    public List<StateActions> actions;

    [ReorderableList(ListStyle.Round)]
    [LabelByChild("DecisionName")]
    public List<StateDecisions> decisions;


    /* [SerializeField]
    public List<StateAction> actions;

    [SerializeField]
    public List<StateDecision> decisions; */


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
     void DoActions(List<StateActions> actions){
        foreach(StateActions Action in actions)
            Action.action.DoAction();
    }
    string MakeDecisions(List<StateDecisions> decisions){
        string state = "";
        foreach(StateDecisions Decision in decisions){
            state = Decision.decision.MakeDecision();
            if(state != "")
                return state;
        }
        return state;
    }

    // fazer um dicionario no brain <string nameState, StateAI> e fazer ele percorrer esse dicionario rodar cada estado
}
