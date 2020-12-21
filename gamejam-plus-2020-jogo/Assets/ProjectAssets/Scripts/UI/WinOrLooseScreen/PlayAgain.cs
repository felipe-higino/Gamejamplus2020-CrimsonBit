using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void OnPress_PlayAgain()
    {
        var mannager = UIManager_GJPlus.Instance as UIManager_GJPlus;
        mannager.ChangeScreen(ScreenGroups.GameHud);
        ReloadScene();
    }
    public void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
