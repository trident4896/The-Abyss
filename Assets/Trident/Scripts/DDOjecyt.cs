using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class DDOjecyt : MonoBehaviour , DragDropHandler {

	private bool IsHeld;
	private GameObject Reticle;
	public Text pressing;


	private bool m_press1;
	private bool m_press2;
	private bool m_press3;
	private bool m_press4;
	// Use this for initialization
	void Start () {
		IsHeld = false;
		//GetComponent<Renderer> ().material.color = Color.yellow;
		Reticle = GameObject.Find ("CardboardReticle");
	}

	// Update is called once per frame
	void Update () {

		m_press1 = CrossPlatformInputManager.GetButton ("Fire1");
		m_press2 = CrossPlatformInputManager.GetButton ("Fire2");
		m_press3 = CrossPlatformInputManager.GetButton ("Fire3");
		m_press4 = CrossPlatformInputManager.GetButton ("Fire4");


		if (IsHeld) {
			if (!Input.GetButtonDown("Fire1")) {
				Ray ray = new Ray (Reticle.transform.position, Reticle.transform.forward);
				transform.position = ray.GetPoint (3f);
			}
		}

	}

	public void HandleGazeTriggerStart() {
		IsHeld = true;
		if (m_press1) {
			pressing.text = "I got pressed";
		}
		/*if (Input.GetKeyDown(KeyCode.JoystickButton0)) {
		GetComponent<Renderer> ().material.color = Color.blue;
		}
		if (Input.GetKeyDown(KeyCode.JoystickButton1)){
			GetComponent<Renderer> ().material.color = Color.red;
		}
		if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
			GetComponent<Renderer> ().material.color = Color.yellow;
		}
		if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
			GetComponent<Renderer> ().material.color = Color.green;
		}*/
	}

	public void HandleGazeTriggerEnd() {
		IsHeld = false;
		//GetComponent<Renderer> ().material.color = Color.yellow;
	}
}
