using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour {

	public int kantongSampah;
	// Use this for initialization
	void Start() {
		kantongSampah = 1;
	}

	// Update is called once per frame
	void Update() {
		GameObject target = GameObject.FindGameObjectWithTag("ResourceText");
		Text targetText = target.GetComponent<Text>();
		targetText.text = "Value: " + kantongSampah;
	}
}
