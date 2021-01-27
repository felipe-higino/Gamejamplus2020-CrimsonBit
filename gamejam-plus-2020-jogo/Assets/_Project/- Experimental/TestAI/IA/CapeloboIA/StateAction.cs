using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class StateAction : MonoBehaviour
{

    [BeginGroup("[ Action ]")]
    [Tooltip("Thats is just a label, to help on organization.")]
    public string ActionName;
    [EndGroup]

    public UnityEvent actionsToDo;

    public virtual void DoAction(){
        Debug.Log("Doing action: "+ActionName);
        if(actionsToDo != null)
            actionsToDo.Invoke();
    }
}
