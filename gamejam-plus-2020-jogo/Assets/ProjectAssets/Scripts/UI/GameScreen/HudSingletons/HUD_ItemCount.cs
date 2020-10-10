using FelipeUtils.Singleton;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class HUD_ItemCount : Singleton<HUD_ItemCount>
{
    //TMP_Text text = null;
    //TMP_Text Text { 
    //    get{
    //        if(text == null)
    //            text = GetComponent<TMP_Text>();
    //        return text;
    //    } 
    //}[

    TMP_Text text = null;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        text.text = $"0/{EventoryInfo.ItemLimit}";
        EventoryInfo.OnEventoryChange +=
            () => text.text = $"{EventoryInfo.EventoryItemCount}/{EventoryInfo.ItemLimit}";
    }
}
