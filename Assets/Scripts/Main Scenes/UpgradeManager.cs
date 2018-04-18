using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class UpgradeType {
	public String name;
	public String displayName;
	public String description;
	public int Level {
		get {
			return (int)core.GetType().GetField(name).GetValue(core);
		}
		set {
			core.GetType().GetField(name).SetValue(core, value);
		}
	}
	//private FieldInfo levels;
	private GameObject prefab;
	private GameObject gObject;
	private Transform parent;
	private GameCore core;
	private PanelController panel;

	public UpgradeType(String name, String displayName, GameObject prefab, Transform parent) {
		this.name = name;
		this.displayName = displayName;
		this.prefab = prefab;
		this.parent = parent;
		core = GameObject.FindGameObjectWithTag("CoreScript").GetComponent<GameCore>();
		description = "Level: ";
	}

	public GameObject Start() {
		gObject = GameObject.Instantiate(prefab, parent, false);
		panel = gObject.GetComponent<PanelController>();
		panel.Name = displayName;
		panel.spriteName = name;
		panel.Description = description + Level;
		panel.Clicker += Add;
		return gObject;
	}

	public void Add() {
		Level++;
		panel.Description = description + Level;
	}
}

public class UpgradeManager : MonoBehaviour {
	[Tooltip("Tempat list upgrade")]
	public GameObject upgradeList;

	[Tooltip("GameObject buat upgrade")]
	public GameObject upgradePrefab;

	private int upgradeCount;

	private GameObject[] upgrades;
	private UpgradeType[] upgradeTypes;
	// Use this for initialization
	void Start() {
		upgradeTypes = new UpgradeType[]{
			new UpgradeType("pemulung", "Bintang", upgradePrefab, upgradeList.transform),
			new UpgradeType("kantongSampah", "Kantong Sampah", upgradePrefab, upgradeList.transform),
			new UpgradeType("tongKecil", "Tong Sampah Kecil", upgradePrefab, upgradeList.transform),
			new UpgradeType("tongBesar", "Tong Sampah Besar", upgradePrefab, upgradeList.transform),
			new UpgradeType("TPA", "Kotak Sampah", upgradePrefab, upgradeList.transform)
		};
		upgradeCount = upgradeTypes.Length;
		upgrades = new GameObject[upgradeCount];
		for (int i = 0; i < upgradeCount; i++) {
			upgrades[i] = upgradeTypes[i].Start();
		}
	}

	// Update is called once per frame
	void Update() {

	}
}
