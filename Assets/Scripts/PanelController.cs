using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {

	public delegate void OnUpgrade();
	public event OnUpgrade Upgrader;

	public delegate void OnUpdate();
	public event OnUpdate Updater;

	// Use this for initialization
	void Start() {
	}

	// Update is called once per frame
	void Update() {
		if (Updater != null)
			Updater();
	}

	public void UpgradeClick() {
		if (Upgrader != null)
			Upgrader();
	}
}
