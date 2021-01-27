using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Brain : MonoBehaviour
{
    
    [Space(32)]    
    [Header("[ BRAIN ]")]
    public string FirstState;
    
    [System.Serializable]
    public struct StateAI_ {
        [SerializeField]string stateName;
        [SerializeField]public StateAI stateAi;
    }
    
    

    [ReorderableList(ListStyle.Round)]
    [LabelByChild("stateName")]
    [SerializeField] List<StateAI_> states;

    [SerializeField,Space(40f),Disable,NewLabel("Current State:")]string stateName;
    
    void Start()
    {
        stateName = FirstState;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current State: "+stateName);
        RunBrainStates();
    }

    StateAI currentState;
    StateAI FindState(string stateSearch){
        if(states == null || states.Count < 1)
            return null;

        if(states.Count == 1)
            return states[0].stateAi;

        foreach(StateAI_ State in states){
            if(State.stateAi.stateName == stateSearch)
                return State.stateAi;
        }

        return null;        
    }

    void RunBrainStates(){
        currentState = FindState(stateName);
        if(currentState == null){
            Debug.Log("Not running any state...");
            stateName = "Not running any state...";
            return;
        }
        stateName = currentState.RunState();
    }
}
