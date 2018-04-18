using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class UpgradeType {
	public String name;
	public String displayName;
	private int level;
	private FieldInfo levels;
	private GameObject prefab;
	private GameObject gObject;
	private Transform parent;
	private GameCore core;

	public UpgradeType(String name, String displayName, GameObject prefab, Transform parent) {
		this.name = name;
		this.displayName = displayName;
		this.prefab = prefab;
		this.parent = parent;
		core = GameObject.FindGameObjectWithTag("CoreScript").GetComponent<GameCore>();
		levels = core.GetType().GetField(name);
		level = (int)levels.GetValue(core);
	}

	public GameObject Start() {
		gObject = GameObject.Instantiate(prefab, parent, false);
		PanelController target = gObject.GetComponent<PanelController>();
		target.Upgrader += Add;
		return gObject;
	}

	public void Add() {
		level++;
		levels.SetValue(core, level);
	}
}

public class UpgradeManager : MonoBehaviour {
	[Tooltip("Tempat list upgrade")]
	public GameObject upgradeList;

	[Tooltip("GameObject buat upgrade")]
	public GameObject upgradePrefab;

	[Tooltip("Banyaknya upgrade")]
	public int upgradeCount;

	private GameObject[] upgrades;
	private UpgradeType[] upgradeTypes;
	private GameCore core;
	// Use this for initialization
	void Start() {
		/*upgrades = new GameObject[upgradeCount];
		for (int i = 0; i < upgradeCount; i++) {
			upgrades[i] = Instantiate(upgradePrefab, upgradeList.transform, false);
		}*/
		core = gameObject.GetComponent<GameCore>();
		upgrades = new GameObject[1];
		upgradeTypes = new UpgradeType[]{
			new UpgradeType("kantongSampah", "Kantong Sampah", upgradePrefab, upgradeList.transform)
		};

		upgrades[0] = upgradeTypes[0].Start();

	}

	// Update is called once per frame
	void Update() {

	}
}
