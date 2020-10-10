using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die_Event : MonoBehaviour
{
	public void OnDie()
	{
		var mannager = UIManager_GJPlus.Instance as UIManager_GJPlus;
		mannager.ChangeScreen(ScreenGroups.LooseScreen);
	}
}
