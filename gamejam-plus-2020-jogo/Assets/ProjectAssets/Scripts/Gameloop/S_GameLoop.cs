using FelipeUtils.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameLoop : Singleton<S_GameLoop>
{
    //load or reload game
    public void LoadGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void DestroyGame()
    {
        Destroy(Persistence.Instance.gameObject);
        SceneManager.LoadScene(0);
    }
}
