using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
	public int count;
	public int value;
	public String name;

	#region UI
	public String displayName;
	private GameObject invUIObject;
	private InvList invList;
	private PanelController panel;
	#endregion

	public Item(String name, String displayName, int value = 1, int count = 0) {
		this.name = name;
		this.count = count;
		this.displayName = displayName;
		this.value = value;
	}

	public void UIStart() {
		invList = new InvList(name, displayName, value);
		invUIObject = invList.Start();
		panel = invUIObject.GetComponent<PanelController>();
		panel.ButtonClicker += UseThis;
	}

	public void UIUpdate() {
		invList.Update();
	}

	public void UseThis() {
		if (count > 0) {
			GameCore.main.money += value;
			count--;
		}
		invList.Update();
	}
}
