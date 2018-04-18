using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour {
	public void DoQuit() {
		Debug.Log("Quit Success");
		Application.Quit();
	}
}