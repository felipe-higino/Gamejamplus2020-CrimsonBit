using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Brain : MonoBehaviour
{
    
    [Space(32)]    
    [Header("[ BRAIN ]")]
    public string FirstState;
    
    string stateName;
    [SerializeField] List<StateAI> states;
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
            return states[0];

        foreach(StateAI state in states){
            if(state.stateName == stateSearch)
                return state;
        }

        return null;        
    }

    void RunBrainStates(){
        currentState = FindState(stateName);
        if(currentState == null){
            Debug.Log("Not running any state...");
            return;
        }
        stateName = currentState.RunState();
    }
}
