using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient{
	public String name;
	public int qty;
	public Ingredient(String name, int qty) {
		this.name = name;
		this.qty = qty;
	}
}

public class Craft {
	public int resultQty;
	public String resultName;
	private Ingredient[] ingredients;

	#region UI
	private String displayName;
	private GameObject craftUIObject;
	private CraftList craftList;
	private PanelController panel;
	#endregion

	public Craft(String resultName, int resultQty, Ingredient[] ingredients) {
		this.resultName = resultName;
		this.resultQty = resultQty;
		this.ingredients = ingredients;
		displayName = GameCore.main.GetItem(resultName).displayName;
	}

	public void UIStart() {
		craftList = new CraftList(resultName, displayName);
		craftUIObject = craftList.Start();
		panel = craftUIObject.GetComponent<PanelController>();
		panel.ButtonClicker += CraftThis;
	}

	public void UIUpdate() {
		craftList.Update();
	}

	public void CraftThis() {
		bool craftAble = true;
		
		foreach (Ingredient i in ingredients) {
			if (GameCore.main.GetItem(i.name).count < i.qty)
				craftAble = false;
		}

		if (craftAble) {
			foreach (Ingredient i in ingredients) {
				GameCore.main.GetItem(i.name).count -= i.qty;
			}
			GameCore.main.GetItem(resultName).count += resultQty;
		}
		craftList.Update();
	}
}
