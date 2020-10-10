using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    public void OnPress_PlayAgain()
    {
        var mannager = UIManager_GJPlus.Instance as UIManager_GJPlus;
        mannager.ChangeScreen(ScreenGroups.GameHud);
        Debug.Log("TODO: RESET GAME!!");
    }
}
