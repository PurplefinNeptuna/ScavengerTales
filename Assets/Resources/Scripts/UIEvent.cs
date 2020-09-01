using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEvent : MonoBehaviour {
	[Tooltip("Tombol Upgrade")]
	public GameObject upgradeButton;

	[Tooltip("Tombol Inventory")]
	public GameObject invButton;

	[Tooltip("Tombol Craft")]
	public GameObject craftButton;

	[Tooltip("UI Upgrade")]
	public GameObject upgradeUI;

	[Tooltip("UI Inventory")]
	public GameObject invUI;

	[Tooltip("UI Craft")]
	public GameObject craftUI;

	public void DoQuit() {
		Debug.Log("Quit Success");
		Application.Quit();
	}

	private void Start() {
		ShowUpgrade();
		upgradeButton.GetComponent<MenuClicker>().PanelClicker += ShowUpgrade;
		invButton.GetComponent<MenuClicker>().PanelClicker += ShowInv;
		craftButton.GetComponent<MenuClicker>().PanelClicker += ShowCraft;
	}

	public void ShowUpgrade() {
		upgradeUI.SetActive(true);
		invUI.SetActive(false);
		craftUI.SetActive(false);
	}

	public void ShowInv() {
		upgradeUI.SetActive(false);
		invUI.SetActive(true);
		craftUI.SetActive(false);
	}

	public void ShowCraft() {
		upgradeUI.SetActive(false);
		invUI.SetActive(false);
		craftUI.SetActive(true);
	}
}