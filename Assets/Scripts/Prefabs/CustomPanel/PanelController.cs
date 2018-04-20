using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler {

	public delegate void OnButtonClick();
	public event OnButtonClick ButtonClicker;

	public delegate void OnUpdate();
	public event OnUpdate Updater;

	public delegate void OnPanelClick();
	public event OnPanelClick PanelClicker;

	public string spriteName;
	public string Name;
	public string ButtonText;
	public string Description;

	private GameObject[] children;
	private GameObject PanelImage;
	private GameObject PanelName;
	private GameObject PanelDescription;
	private GameObject PanelButton;

	private void Awake() {
		children = GetComponentsInChildren<Transform>(true).Where(i => i.parent == transform).Select(i => i.gameObject).ToArray();
		PanelImage = children.SingleOrDefault(i => i.name == "PanelImage");
		PanelName = children.SingleOrDefault(i => i.name == "PanelName");
		PanelDescription = children.SingleOrDefault(i => i.name == "PanelDescription");
		PanelButton = children.SingleOrDefault(i => i.name == "PanelButton");
	}
	// Use this for initialization
	void Start() {
		PanelImage.GetComponent<Image>().sprite = GameCore.main.GetSprite(spriteName);
		PanelName.GetComponent<Text>().text = Name;
		PanelButton.GetComponentInChildren<Text>();
	}
	// Update is called once per frame
	void Update() {
		PanelDescription.GetComponent<Text>().text = Description;
		PanelButton.GetComponentInChildren<Text>(true).text = ButtonText ?? "Test";
		if (Updater != null)
			Updater();
	}

	public void ButtonClick() {
		if (ButtonClicker != null)
			ButtonClicker();
	}

	public void OnPointerClick(PointerEventData e) {
		if (PanelClicker != null)
			PanelClicker();
	}

	public void OnPointerDown(PointerEventData e) {
	}

	public void OnPointerUp(PointerEventData e) {
	}
}
