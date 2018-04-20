using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour {

	public static GameCore main;

	private Sprite[] spriteList;
	private Upgrade[] upgrades;
	private Item[] items;
	private Craft[] crafts;
	public int money;
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

	public Item GetItem(String name) {
		return items.First(i => i.name == name);
	}

	public Craft GetCraft(String name) {
		return crafts.First(i => i.resultName == name);
	}

	public Upgrade GetUpgrade(String name) {
		return upgrades.First(i => i.name == name);
	}

	public Sprite GetSprite(String name) {
		return spriteList.First(i => i.name == name);
	}

	void Awake() {
		if (main == null) {
			main = this;
			Initialize();
		}
		else if (main != this) {
			Destroy(gameObject);
		}
	}

	private void Initialize() {
		money = 0;
		spriteList = Resources.LoadAll<Sprite>("Sprites/spritesheets");
		upgrades = new[]{
			new Upgrade("pemulung", "Bintang"),
			new Upgrade("kantongSampah", "Kantong Sampah"),
			new Upgrade("tongKecil", "Tong Sampah Kecil"),
			new Upgrade("tongBesar", "Tong Sampah Besar"),
			new Upgrade("TPA", "Kotak Sampah")
		};
		items = new[]{
			new Item("botol", "Botol Bekas", 5, 10),
			new Item("botolAir", "Botol Isi Air", 10, 10),
			new Item("kayu", "Kayu", 8, 10),
			new Item("kertas", "Sampah Kertas", 3, 10),
			new Item("mainan", "Mainan", 25, 10),
			new Item("makanan", "Makanan Sisa", 12, 10),
			new Item("origami", "Origami Kertas", 6, 10),
			new Item("plastik", "Plastik Bekas", 2, 10)
		};
		crafts = new[]{
			new Craft("botolAir", 1, new[]{
				new Ingredient("botol", 1)
			}),
			new Craft("origami", 1, new[]{
				new Ingredient("kertas", 2)
			}),
			new Craft("mainan", 2, new[]{
				new Ingredient("kayu", 2),
				new Ingredient("botol", 1),
				new Ingredient("plastik", 1)
			})
		};
	}

	private void Start() {
		foreach (Upgrade i in upgrades) {
			i.UIStart();
		}
		foreach (Item i in items) {
			i.UIStart();
		}
		foreach (Craft i in crafts) {
			i.UIStart();
		}
	}

	// Update is called once per frame
	void Update() {
		foreach (Upgrade i in upgrades) {
			i.UIUpdate();
		}
		foreach (Item i in items) {
			i.UIUpdate();
		}
		foreach (Craft i in crafts) {
			i.UIUpdate();
		}
		GameObject target = GameObject.FindGameObjectWithTag("ResourceText");
		Text targetText = target.GetComponent<Text>();
		targetText.text = "Money: " + money;
		for (int i = 0; i < upgrades.Length; i++) {
			targetText.text += "\nValue" + (i+1) + ": " + upgrades[i].level;
		}
	}
}
