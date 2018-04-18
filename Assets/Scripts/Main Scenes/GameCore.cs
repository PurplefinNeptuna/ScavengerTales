using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour {

	public int pemulung;
	public int kantongSampah;
	public int tongKecil;
	public int tongBesar;
	public int TPA;
	// Use this for initialization
	void Awake() {
		pemulung = 1;
		kantongSampah = 1;
		tongKecil = 1;
		tongBesar = 1;
		TPA = 1;
	}

	// Update is called once per frame
	void Update() {
		GameObject target = GameObject.FindGameObjectWithTag("ResourceText");
		Text targetText = target.GetComponent<Text>();
		targetText.text = "Value1: " + pemulung + "\nValue2: " + kantongSampah + "\nValue3: " + tongKecil + "\nValue4: " + tongBesar + "\nValue5: " + TPA;
	}
}
