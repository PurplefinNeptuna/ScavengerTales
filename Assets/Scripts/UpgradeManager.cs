using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {
	[Tooltip("Tempat list upgrade")]
	public GameObject upgradeList;

	[Tooltip("GameObject buat upgrade")]
	public GameObject upgradePrefab;

	[Tooltip("Banyaknya upgrade")]
	public int upgradeCount;

	private GameObject[] upgrades;
	// Use this for initialization
	void Start () {
		upgrades = new GameObject[upgradeCount];
		for (int i = 0; i < upgradeCount; i++) {
			upgrades[i] = Instantiate(upgradePrefab, upgradeList.transform, false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
