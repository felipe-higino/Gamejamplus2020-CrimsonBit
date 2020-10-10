using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Event : MonoBehaviour
{
    public void OnWin()
    {
        var mannager = UIManager_GJPlus.Instance as UIManager_GJPlus;
        mannager.ChangeScreen(ScreenGroups.WinScreen);
    }
}
