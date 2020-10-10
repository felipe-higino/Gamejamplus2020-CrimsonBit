using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FelipeUtils.UIMannagement;

public class UIHidable_GJPlus : UIHidablePerformant
{
	public override void Show()
	{
		base.Show();
		//Debug.Log("PlayFadein");
	}

	public override void Hide()
	{
		base.Hide();
		//Debug.Log("PlayFadeout");
	}
}
