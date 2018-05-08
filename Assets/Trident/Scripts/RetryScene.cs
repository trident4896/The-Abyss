using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class RetryScene : MonoBehaviour {

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

		if (m_press4) {
			SceneManager.LoadScene ("Test");
		}
	}
}
