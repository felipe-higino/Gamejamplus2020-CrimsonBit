using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FelipeUtils.UIMannagement;

public enum ScreenGroups
{
    MainScreen,
    GameHud,
    PauseScreen,
    WinScreen,
    LooseScreen,
}

public class UIManager_GJPlus : UIMannager
{
    private void Start()
    {
        HideAll();
        //shows just the number one screen
        if (Screens.Length <= 0)
        {
            Destroy(gameObject);
            return;
        }

        actualScreen = ScreenGroups.MainScreen;
        previousScreen = ScreenGroups.MainScreen;
        Screens[(int)ScreenGroups.MainScreen].Show();

    }
    private ScreenGroups actualScreen;
    private ScreenGroups previousScreen;
    public ScreenGroups PreviousScreen { get => previousScreen; }

    public void ChangeScreen(ScreenGroups newScreen)
    {
        if (actualScreen == newScreen)
            return;

        HideAll();
        Screens[(int)newScreen].Show();

        previousScreen = actualScreen;
        actualScreen = newScreen;
    }
}
