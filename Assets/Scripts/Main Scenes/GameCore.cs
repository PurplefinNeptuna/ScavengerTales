using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour {

	public static Sprite[] spriteList;
	public static Upgrade[] upgrades;
	public static Item[] items;
	public static int money;
	// Use this for initialization

	[Tooltip("Tempat list upgradeUI")]
	public GameObject upgradeList;

	[Tooltip("GameObject buat upgradeUI")]
	public GameObject upgradePrefab;

	[Tooltip("Tempat list invUI")]
	public GameObject invList;

	[Tooltip("GameObject buat invUI")]
	public GameObject invPrefab;

	[Tooltip("Tempat list craftUI")]
	public GameObject craftList;

	[Tooltip("GameObject buat craftUI")]
	public GameObject craftPrefab;

	void Awake() {
		money = 0;
		spriteList = Resources.LoadAll<Sprite>("Sprites/spritesheets");
		upgrades = new[]{
			new Upgrade("pemulung", "Bintang", upgradeList.transform, upgradePrefab),
			new Upgrade("kantongSampah", "Kantong Sampah", upgradeList.transform, upgradePrefab),
			new Upgrade("tongKecil", "Tong Sampah Kecil", upgradeList.transform, upgradePrefab),
			new Upgrade("tongBesar", "Tong Sampah Besar", upgradeList.transform, upgradePrefab),
			new Upgrade("TPA", "Kotak Sampah", upgradeList.transform, upgradePrefab)
		};
		items = new[]{
			new Item("botol", "Botol Bekas", invList.transform, invPrefab, 5, 10),
			new Item("botolAir", "Botol Isi Air", invList.transform, invPrefab, 10, 10),
			new Item("kayu", "Kayu", invList.transform, invPrefab, 8, 10),
			new Item("kertas", "Sampah Kertas", invList.transform, invPrefab, 3, 10),
			new Item("mainan", "Mainan", invList.transform, invPrefab, 25, 10),
			new Item("makanan", "Makanan Sisa", invList.transform, invPrefab, 12, 10),
			new Item("origami", "Origami Kertas", invList.transform, invPrefab, 6, 10),
			new Item("plastik", "Plastik Bekas", invList.transform, invPrefab, 2, 10)
		};
	}

	private void Start() {
		foreach (Upgrade i in upgrades) {
			i.UIStart();
		}
		foreach (Item i in items) {
			i.UIStart();
		}
	}

	// Update is called once per frame
	void Update() {
		GameObject target = GameObject.FindGameObjectWithTag("ResourceText");
		Text targetText = target.GetComponent<Text>();
		targetText.text = "Money: " + money;
		for (int i = 0; i < upgrades.Length; i++) {
			targetText.text += "\nValue" + (i+1) + ": " + upgrades[i].level;
		}
	}
}
