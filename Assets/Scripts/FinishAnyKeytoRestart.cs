﻿using UnityEngine;
using System.Collections;

public class FinishAnyKeytoRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown)
		{
			PlayerPrefs.SetInt ("Level1Multipliers", 1);
			Application.LoadLevel (PlayerPrefs.GetString ("Level1"));
		}
	
	}
}