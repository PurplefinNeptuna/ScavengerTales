using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
	public int count;
	public int value;
	public String name;

	#region UI
	private String displayName;
	private Transform parent;
	private GameObject prefab;
	private GameObject invUIObject;
	private InvList invList;
	private PanelController panel;
	#endregion

	public Item(String name, String displayName, Transform parent, GameObject prefab, int value = 1, int count = 0) {
		this.name = name;
		this.count = count;
		this.displayName = displayName;
		this.parent = parent;
		this.prefab = prefab;
		this.value = value;
	}

	public void UIStart() {
		invList = new InvList(name, displayName, value, prefab, parent);
		invUIObject = invList.Start();
		panel = invUIObject.GetComponent<PanelController>();
		panel.ButtonClicker += UseThis;
	}

	public void UseThis() {
		if (count > 0) {
			GameCore.money += value;
			count--;
		}
		invList.Update();
	}
}
