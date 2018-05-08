using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Cursor.visible = false;

		if (Input.GetKey (KeyCode.L)) {
			SceneManager.LoadScene ("Test");
		}

		if (Input.GetKey (KeyCode.K)) {
			SceneManager.LoadScene ("MenuScene 1");
		}
	}
}
