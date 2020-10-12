using FelipeUtils.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameLoop : Singleton<S_GameLoop>
{
    //load or reload game
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void DestroyGame()
    {
        Destroy(Persistence.Instance.gameObject);
        SceneManager.LoadScene(0);
    }
}
