using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEvent : MonoBehaviour {
	public void DoQuit() {
		Debug.Log("Quit Success");
		Application.Quit();
	}
}