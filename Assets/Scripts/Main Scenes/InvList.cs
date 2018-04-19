using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvList {
	public String name;
	public String displayName;
	public String infoDisplay;
	public String buttonText;
	public String details;
	public int value;
	public int Count {
		get {
			return GameCore.items.SingleOrDefault(i => i.name == name).count;
		}
	}

	private GameObject prefab;
	private GameObject gObject;
	private Transform parent;
	private PanelController panel;

	public InvList(String name, String displayName,int value, GameObject prefab, Transform parent, String buttonText = "Sell", String details = "Lol") {
		this.name = name;
		this.displayName = displayName;
		this.value = value;
		this.prefab = prefab;
		this.parent = parent;
		infoDisplay = "Value: ";
		this.buttonText = buttonText;
		this.details = details;
	}

	public GameObject Start() {
		gObject = GameObject.Instantiate(prefab, parent, false);
		panel = gObject.GetComponent<PanelController>();
		panel.Name = displayName;
		panel.spriteName = name;
		panel.Description = infoDisplay + value + "\t\tCount: " + Count;
		panel.ButtonText = buttonText;
		//panel.Updater += Update;
		return gObject;
	}

	public void Update() {
		panel.Name = displayName;
		panel.spriteName = name;
		panel.Description = infoDisplay + value + "\t\tCount: " + Count;
	}
}
