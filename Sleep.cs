using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
	DisableControls disableControls;
	Character character;
	DayTimeController dayTime;
	private void Awake()
	{
		disableControls = GetComponent<DisableControls>();
		character = GetComponent<Character>();
		dayTime = GameManager.instance.timeController;
	}

	internal void DoSleep()
	{
		StartCoroutine(SleepRoutine());
	}

	IEnumerator SleepRoutine()
	{
		ScreeTint screeTint =   GameManager.instance.screeTint;

		disableControls.DisableControl();

		screeTint.Tint();

		yield return new WaitForSeconds(2f);

		character.FullHeal();
		character.FullRest(0);
		dayTime.SkipToMorning();


		screeTint.UnTint();

		yield return new WaitForSeconds(2f);

		disableControls.EnableControl();

		yield return null;
	}
	
}
