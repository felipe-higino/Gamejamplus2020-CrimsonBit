using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

#region Classes Rotuladas
[System.Serializable]
public struct States{
    [SerializeField]public StateAI state;
}
#endregion

[System.Serializable]
public class Brain : MonoBehaviour
{
    
    [Header("[ BRAIN ]")]
    public string FirstState;
    
      
    //[ReorderableList(ListStyle.Round)]
    //[LabelByChild("name")]
    [SerializeField,Space(40)] List<States> states;


    [SerializeField,Space(40f),Disable,NewLabel("Current State:")]string stateName;
    [SerializeField,Disable,NewLabel("Current Decision:")]string stateDecision;
    
    bool brainExecution = true;
    public void StopBrain(bool stop){
        stateName = FirstState;
        currentState = FindState(stateName);
        brainExecution = !stop;
    }
    void Start()
    {
        stateName = FirstState;
    }

    // Update is called once per frame
    void Update()
    {
        RunBrainStates(brainExecution);
    }

    StateAI currentState;
    StateAI FindState(string stateSearch){
        //if not have any state in machine, abort.
        if(states == null || states.Count < 1)
            return null;

        //if have only one state in machine, return it.
        if(states.Count == 1)
            return states[0].state;

        //if machine have more states...
        foreach(States current in states){
            if(current.state.name == stateSearch)
                return current.state;
        }

        return null;        
    }

    void RunBrainStates(bool runBrain){
        if(!runBrain)return;

        currentState = FindState(stateName);
        if(currentState == null){
            stateName = "Not running any state...";
            stateDecision = "...";
            return;
        }
        stateName = currentState.RunState();
        stateDecision = currentState.currentDecision;
    }

}


