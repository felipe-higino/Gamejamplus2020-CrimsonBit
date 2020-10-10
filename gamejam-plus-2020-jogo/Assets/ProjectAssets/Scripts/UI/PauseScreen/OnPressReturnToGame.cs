using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressReturnToGame : MonoBehaviour
{
    public void OnPress_Unpause()
    {
        var mannager = UIManager_GJPlus.Instance as UIManager_GJPlus;
        mannager.ChangeScreen(ScreenGroups.GameHud);
        Debug.Log("TODO: UNPAUSE!");
    }
}
