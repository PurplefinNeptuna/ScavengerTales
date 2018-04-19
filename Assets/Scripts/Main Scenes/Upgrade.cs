using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade {
	public int level;
	public String name;

	#region UI
	private String displayName;
	private Transform parent;
	private GameObject prefab;
	private GameObject upgradeUIObject;
	private UpgradeList upgradeList;
	private PanelController panel;
	#endregion

	public Upgrade(String name, String displayName, Transform parent, GameObject prefab) {
		this.name = name;
		level = 0;
		this.displayName = displayName;
		this.parent = parent;
		this.prefab = prefab;
	}

	public void UIStart() {
		upgradeList = new UpgradeList(name, displayName, prefab, parent);
		upgradeUIObject = upgradeList.Start();
		panel = upgradeUIObject.GetComponent<PanelController>();
		panel.ButtonClicker += Add;
	}

	public void Add() {
		level++;
		upgradeList.Update();
	}
}
