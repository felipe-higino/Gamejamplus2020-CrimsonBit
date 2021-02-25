using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : StateDecision
{
    bool changeChange = false;

    public void NextState(bool go){
        changeChange = go;
    }

    public void ChangeTo(string newState){
        this.IfTrue = newState;
    }



    public override bool CheckCondition(){
        if(changeChange){
            changeChange = false;
            return true;
        }else{
            return false;
        }

    }
}
