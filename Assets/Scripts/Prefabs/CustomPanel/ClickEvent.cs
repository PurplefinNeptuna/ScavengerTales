﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour {

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public void OnMouseUpAsButton() {
		string Name = gameObject.GetComponent<PanelController>().Name;
		Debug.Log("Clicked " + Name);
	}
}
