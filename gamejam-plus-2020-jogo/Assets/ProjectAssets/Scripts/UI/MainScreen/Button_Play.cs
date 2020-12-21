using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Play : MonoBehaviour
{

    public void OnSubmit_Play()
    {
        var mannager = UIManager_GJPlus.Instance as UIManager_GJPlus;
        mannager.ChangeScreen(ScreenGroups.GameHud);
    }
    public void LoadScene(string scene){
        SceneManager.LoadScene(scene);
    }
}
