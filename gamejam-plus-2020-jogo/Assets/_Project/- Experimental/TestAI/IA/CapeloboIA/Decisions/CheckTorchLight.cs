using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckTorchLight : StateDecision
{
    [BeginGroup("Specific Parameters:")]
    [Header("This decision verify the distance between monster and the protected light area.")]
    public TorchLight torch;
    [EndGroup]
    public ComparisionMode condition;



    public override bool CheckCondition()
    {

        if(condition == ComparisionMode.BiggerOrEqual)
            return Vector3.Distance(transform.position, torch.transform.position) >= torch.getLightProtection();

        if(condition == ComparisionMode.LessOrEqual)
            return Vector3.Distance(transform.position, torch.transform.position) <= torch.getLightProtection();

        if(condition == ComparisionMode.BiggerThen)
            return Vector3.Distance(transform.position, torch.transform.position) > torch.getLightProtection();

        if(condition == ComparisionMode.LessThan)
            return Vector3.Distance(transform.position, torch.transform.position) < torch.getLightProtection();

        if(condition == ComparisionMode.Equals)
            return Vector3.Distance(transform.position, torch.transform.position) == torch.getLightProtection();

        //if ComparisionMode.Different
        return Vector3.Distance(transform.position, torch.transform.position) != torch.getLightProtection();


    }
}
