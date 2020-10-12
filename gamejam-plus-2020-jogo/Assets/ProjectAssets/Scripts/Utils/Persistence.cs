using FelipeUtils.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistence : Singleton<Persistence>
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
