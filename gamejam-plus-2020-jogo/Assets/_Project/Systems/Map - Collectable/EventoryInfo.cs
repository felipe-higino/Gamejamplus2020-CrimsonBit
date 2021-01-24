using System;
using System.Collections;
using System.Collections.Generic;

public static class EventoryInfo
{
	public static int ItemLimit { get => 7; }

	private static int eventoryItemCount = 0;
	public static int EventoryItemCount
	{
		set
		{
			if (value > ItemLimit)
				return;
			if (value < 0)
				return;
			eventoryItemCount = value;
			OnEventoryChange?.Invoke();

		}
		get => eventoryItemCount;
	}
	public static event Action OnEventoryChange;
}
