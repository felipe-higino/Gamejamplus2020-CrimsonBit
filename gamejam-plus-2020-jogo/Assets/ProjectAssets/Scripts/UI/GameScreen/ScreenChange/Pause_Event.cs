using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Event : MonoBehaviour
{
    public void OnPause()
    {
        var mannager = UIManager_GJPlus.Instance as UIManager_GJPlus;
        mannager.ChangeScreen(ScreenGroups.PauseScreen);
    }
}
