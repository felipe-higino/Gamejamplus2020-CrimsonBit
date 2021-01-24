using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class StateAction : MonoBehaviour
{
    [Space(32)]
    [Header("[ Action ]")]
    [Tooltip("Thats is just a label, to help on organization.")]
    public string ActionName;

    public UnityEvent actionsToDo;

    public virtual void DoAction(){
        Debug.Log("Doing action: "+ActionName);
        if(actionsToDo != null)
            actionsToDo.Invoke();
    }
}
