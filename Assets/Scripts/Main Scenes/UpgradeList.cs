using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeList {
	public String name;
	public String displayName;
	public String levelDisplay;
	public String buttonText;
	public String details;
	public int Level {
		get {
			return GameCore.main.upgrades.SingleOrDefault(i => i.name == name).level;
		}
	}

	private GameObject prefab;
	private GameObject gObject;
	private Transform parent;
	private PanelController panel;

	public UpgradeList(String name, String displayName, String buttonText = "Upgrade", String details = "Lol") {
		this.name = name;
		this.displayName = displayName;
		levelDisplay = "Level: ";
		this.buttonText = buttonText;
		this.details = details;
		prefab = GameCore.main.upgradePrefab;
		parent = GameCore.main.upgradeList.transform;
	}

	public GameObject Start() {
		gObject = GameObject.Instantiate(prefab, parent, false);
		panel = gObject.GetComponent<PanelController>();
		panel.Name = displayName;
		panel.spriteName = name;
		panel.Description = levelDisplay + Level;
		panel.ButtonText = buttonText;
		//panel.Updater += Update;
		return gObject;
	}

	public void Update() {
		panel.Name = displayName;
		panel.spriteName = name;
		panel.Description = levelDisplay + Level;
	}
}
