using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckTorchLight : StateDecision
{
    [BeginGroup("Specific Parameters:")]
    [Header("This decision verify the distance between monster and the protected light area.")]
    public TorchLight torch;
    public ComparisionMode condition;
    [SerializeField]bool stealthAprouch = false;
    [EndGroup]
    [SerializeField,Tooltip("Zero is 180°, One is 0°"),Range(0f,1f), ShowIf("stealthAprouch",true)]float angleRange;



    public override bool CheckCondition()
    {
        Transform target = torch.transform;

        if(!stealthAprouch){
            if(condition == ComparisionMode.BiggerOrEqual)
                return Vector3.Distance(transform.position, target.position) >= torch.getLightProtection();

            if(condition == ComparisionMode.LessOrEqual)
                return Vector3.Distance(transform.position,  target.position) <= torch.getLightProtection();

            if(condition == ComparisionMode.BiggerThen)
                return Vector3.Distance(transform.position,  target.position) > torch.getLightProtection();

            if(condition == ComparisionMode.LessThan)
                return Vector3.Distance(transform.position,  target.position) < torch.getLightProtection();

            if(condition == ComparisionMode.Equals)
                return Vector3.Distance(transform.position,  target.position) == torch.getLightProtection();

            //if ComparisionMode.Different
            return Vector3.Distance(transform.position,  target.position) != torch.getLightProtection();
        }else{
            Vector3 targetDirection = transform.position - target.position;
            float direction = Vector3.Dot(targetDirection.normalized,target.forward);

            if(condition == ComparisionMode.BiggerOrEqual)
                return Vector3.Distance(transform.position, target.position) >= torch.getLightProtection() && direction > angleRange;

            if(condition == ComparisionMode.LessOrEqual)
                return Vector3.Distance(transform.position,  target.position) <= torch.getLightProtection() && direction > angleRange;

            if(condition == ComparisionMode.BiggerThen)
                return Vector3.Distance(transform.position,  target.position) > torch.getLightProtection() && direction > angleRange;

            if(condition == ComparisionMode.LessThan)
                return Vector3.Distance(transform.position,  target.position) < torch.getLightProtection() && direction > angleRange;

            if(condition == ComparisionMode.Equals)
                return Vector3.Distance(transform.position,  target.position) == torch.getLightProtection() && direction > angleRange;

            //if ComparisionMode.Different
            return Vector3.Distance(transform.position,  target.position) != torch.getLightProtection() && direction > angleRange;

        }


    }
}
