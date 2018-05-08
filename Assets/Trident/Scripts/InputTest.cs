using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class InputTest : MonoBehaviour {

	public Text test;
	private bool m_press1;
	private bool m_press2;
	private bool m_press3;
	private bool m_press4;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		m_press1 = CrossPlatformInputManager.GetButton ("Fire1"); //A //joystick 0

		m_press2 = CrossPlatformInputManager.GetButton ("Fire2"); //B //joystick 1
		 
		m_press3 = CrossPlatformInputManager.GetButton ("Fire3"); //X //joystick 2

		m_press4 = CrossPlatformInputManager.GetButton ("Fire4"); //Y //joystick 3



		/*if  (Input.GetKeyDown(KeyCode.BackQuote)) {
		GetComponent<Renderer> ().material.color = Color.blue;
		}

		if (Input.GetKeyDown(KeyCode.A)){
			GetComponent<Renderer> ().material.color = Color.red;
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			GetComponent<Renderer> ().material.color = Color.yellow;
		}

		if (Input.GetKeyDown (KeyCode.D)) {
			GetComponent<Renderer> ().material.color = Color.green;
		}*/

		if (m_press1) {
				test.text = "Pressed A";
		}

		if (m_press2) {
				test.text = "Pressed B";
		}

		if (m_press3) {
				test.text = "Pressed X";
		}

		if (m_press4) {
				test.text = "Pressed Y";
		}

		/*if (Input.anyKeyDown) {
			Debug.Log (Input.inputString);
			test.text = Input.inputString;
		}*/
 }
}
