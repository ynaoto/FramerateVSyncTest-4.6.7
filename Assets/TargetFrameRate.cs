﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TargetFrameRate : MonoBehaviour {
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Application.targetFrameRate = " + Application.targetFrameRate;
	}

	public void Set(int v) {
		Application.targetFrameRate = v;
	}
}
