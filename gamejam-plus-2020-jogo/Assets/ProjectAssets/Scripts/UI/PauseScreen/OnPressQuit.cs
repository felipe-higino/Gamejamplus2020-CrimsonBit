using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressQuit : MonoBehaviour
{
    public void OnPress_Quit()
    {
        var mannager = UIManager_GJPlus.Instance as UIManager_GJPlus;
        mannager.ChangeScreen(ScreenGroups.MainScreen);
        Debug.Log("TODO: reset all");
    }
}
