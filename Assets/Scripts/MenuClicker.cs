using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuClicker : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler {

	public delegate void OnPanelClick();
	public event OnPanelClick PanelClicker;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public void OnPointerClick(PointerEventData e) {
		if (PanelClicker != null)
			PanelClicker();
		Debug.Log("ButtonClicked from " + gameObject.name);
	}

	public void OnPointerDown(PointerEventData e) {
	}

	public void OnPointerUp(PointerEventData e) {
	}

}
