using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HUD_GunImage : MonoBehaviour
{
    //Image image = null;
    //Image Image
    //{
    //    get
    //    {
    //        if (image == null)
    //            image = GetComponent<Image>();
    //        return image;
    //    }
    //}
    Image image = null;
    private void Awake()
    {
        image = GetComponent<Image>();
        EventoryInfo.OnEventoryChange +=
            () => {
                Debug.Log("TODO: change image!");
            };
    }
}
