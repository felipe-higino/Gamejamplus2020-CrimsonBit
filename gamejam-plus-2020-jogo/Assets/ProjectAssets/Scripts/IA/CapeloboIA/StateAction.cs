using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAction : MonoBehaviour
{
    [Space(32)]
    [Header("[ Action ]")]
    [Tooltip("Thats is just a label, to help on organization.")]
    public string ActionName;


    public virtual void DoAction(){
        Debug.Log("Doing action: "+ActionName);
    }
}
