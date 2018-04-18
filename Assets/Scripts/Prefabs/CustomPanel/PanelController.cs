using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour {

	public delegate void OnClick();
	public event OnClick Clicker;

	public delegate void OnUpdate();
	public event OnUpdate Updater;

	public string spriteName;
	public string Name;
	public string Description;

	private GameObject[] children;
	private GameObject PanelImage;
	private GameObject PanelName;
	private GameObject PanelDescription;
	private GameObject PanelButton;

	private void Awake() {
		children = GetComponentsInChildren<Transform>().Where(i => i.parent == transform).Select(i => i.gameObject).ToArray();
		PanelImage = children.SingleOrDefault(i => i.name == "PanelImage");
		PanelName = children.SingleOrDefault(i => i.name == "PanelName");
		PanelDescription = children.SingleOrDefault(i => i.name == "PanelDescription");
		PanelButton = children.SingleOrDefault(i => i.name == "PanelButton");
	}
	// Use this for initialization
	void Start() {
		PanelImage.GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("Sprites/spritesheets").SingleOrDefault(i => i.name == spriteName);
		PanelName.GetComponent<Text>().text = Name;
	}
	// Update is called once per frame
	void Update() {
		PanelDescription.GetComponent<Text>().text = Description;
		if (Updater != null)
			Updater();
	}

	public void Click() {
		if (Clicker != null)
			Clicker();
	}
}
