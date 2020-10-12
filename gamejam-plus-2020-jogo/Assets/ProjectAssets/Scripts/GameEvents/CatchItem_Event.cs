using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItem_Event : MonoBehaviour
{
    public void On_CatchItem()
    {
        EventoryInfo.EventoryItemCount += 1;
    }
}
