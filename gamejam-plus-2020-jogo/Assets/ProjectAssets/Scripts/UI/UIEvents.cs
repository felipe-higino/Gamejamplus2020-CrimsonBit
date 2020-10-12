using FelipeUtils.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Win_Event))]
[RequireComponent(typeof(Die_Event))]
[RequireComponent(typeof(Pause_Event))]
[RequireComponent(typeof(CatchItem_Event))]

public class UIEvents : Singleton<UIEvents>
{
	Win_Event win;
	Die_Event die;
	Pause_Event pause;
	CatchItem_Event catchItem;

	public Win_Event Win { get => win; }
	public Die_Event Die { get => die; }
	public Pause_Event Pause { get => pause; }
	public CatchItem_Event CatchItem { get => catchItem; }

	private void Awake()
	{
		win = GetComponent<Win_Event>();
		die = GetComponent<Die_Event>();
		pause = GetComponent<Pause_Event>();
		catchItem = GetComponent<CatchItem_Event>();
	}


}
