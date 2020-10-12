using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("Player"))
            GameLoopManager.instance.ReloadScene();
    }
}
