﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney = 10;

	void Start()
	{
		Money = startMoney;
		Debug.Log(Money.ToString());

	}

}
