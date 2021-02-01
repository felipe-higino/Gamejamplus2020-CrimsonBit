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
            return states[0].state;

        foreach(States current in states){
            if(/* current.name == stateSearch || */ current.state.name == stateSearch)
                return current.state;
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


