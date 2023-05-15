using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Stat
{
	public int maxVal;
	public int currentVal;

	

	public Stat(int curr, int max)
	{
		maxVal = max;
		currentVal = curr;


	}

	internal void Subtract(int amount)
	{
		currentVal -= amount;
	}

	internal void Add(int amount)
	{
		currentVal += amount;

		if(currentVal >maxVal) { currentVal = maxVal; }
	}

	internal void SetToMax()
	{
		currentVal = maxVal;
	}
}
public class Character : MonoBehaviour,IDamageable
{
	public Stat hp;
	[SerializeField] StatusBar hpBar;
	public Stat stamina;
	[SerializeField] StatusBar staminaBar;
	public bool isDead;
	public bool isExhausted;

	DisableControls disableControls;
	PlayerRespawn playerRespawn;

	private void Awake()
	{
		disableControls = GetComponent<DisableControls>();
		playerRespawn = GetComponent<PlayerRespawn>();
	}
	public void Start()
	{
	
		UpdateHPBar();
		UpdateStaminaBar();
	}

	private void UpdateStaminaBar()
	{
		staminaBar.Set(stamina.currentVal, stamina.maxVal);
	}
	

	public void TakeDamage(int amount)
	{
		if(isDead == true) { return; }
		hp.Subtract(amount);
		if(hp.currentVal <=0 )
		{
			Dead();
		}
		UpdateHPBar();
	}

	private void Dead()
	{
		isDead = true;
		disableControls.DisableControl();
		playerRespawn.StartRespawn();
	}

	private void UpdateHPBar()
	{
		hpBar.Set(hp.currentVal, hp.maxVal);
	}

	public void Heal(int amount)
	{
		hp.Add(amount);
		UpdateHPBar();
	}

	public void FullHeal()
	{
		hp.SetToMax();
		UpdateHPBar();
	}
	public void GetTired(int amount)
	{
		stamina.Subtract(amount);
		if(stamina.currentVal <0)
		{
			Exhausted();
		}
		UpdateStaminaBar();
	}

	private void Exhausted()
	{
		isExhausted = true;
		disableControls.DisableControl();
		playerRespawn.StartRespawn();
	}

	public void Rest(int amount)
	{
		stamina.Add(amount);
		UpdateStaminaBar();
	}

	public void FullRest(int amount)
	{
		stamina.SetToMax();
		UpdateStaminaBar();
	}

	public void CalculateDamage(ref int damage)
	{
		
	}

	public void ApplyDamage(int damage)
	{
		TakeDamage(damage);
	}

	public void CheckState()
	{
		
	}
}
