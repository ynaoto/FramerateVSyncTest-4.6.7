using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FPS : MonoBehaviour {
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		//Application.targetFrameRate = 30;
		//QualitySettings.vSyncCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = (int)(1/Time.deltaTime) + "fps";
	}
}
