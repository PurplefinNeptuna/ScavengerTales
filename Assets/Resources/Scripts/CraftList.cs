using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftList {
	public String name;
	public String displayName;
	public String resultDisplay;
	public String buttonText;
	public String details;
	public int Qty {
		get {
			return GameCore.main.GetCraft(name).resultQty;
		}
	}

	private GameObject prefab;
	private GameObject gObject;
	private Transform parent;
	private PanelController panel;

	public CraftList(String name, String displayName, String buttonText = "Craft", String details = "Lol") {
		this.name = name;
		this.displayName = displayName;
		resultDisplay = "Qty: ";
		this.buttonText = buttonText;
		this.details = details;
		prefab = GameCore.main.craftPrefab;
		parent = GameCore.main.craftList.transform;
	}

	public GameObject Start() {
		gObject = GameObject.Instantiate(prefab, parent, false);
		panel = gObject.GetComponent<PanelController>();
		panel.Name = displayName;
		panel.spriteName = name;
		panel.Description = resultDisplay + Qty;
		panel.ButtonText = buttonText;
		//panel.Updater += Update;
		return gObject;
	}

	public void Update() {
		panel.Name = displayName;
		panel.spriteName = name;
		panel.Description = resultDisplay + Qty;
	}
}
