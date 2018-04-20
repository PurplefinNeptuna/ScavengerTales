using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade {
	public int level;
	public String name;

	#region UI
	private String displayName;
	private GameObject upgradeUIObject;
	private UpgradeList upgradeList;
	private PanelController panel;
	#endregion

	public Upgrade(String name, String displayName) {
		this.name = name;
		level = 0;
		this.displayName = displayName;
	}

	public void UIStart() {
		upgradeList = new UpgradeList(name, displayName);
		upgradeUIObject = upgradeList.Start();
		panel = upgradeUIObject.GetComponent<PanelController>();
		panel.ButtonClicker += Add;
	}

	public void UIUpdate() {
		upgradeList.Update();
	}

	public void Add() {
		level++;
		upgradeList.Update();
	}
}
