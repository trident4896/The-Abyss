using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningTrigger : MonoBehaviour {

	public GameObject summonCircle;
	int correctObject;
	Material mat;
	// Use this for initialization
	void Start () {
		mat = summonCircle.GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (correctObject == 4) 
		{
			// Put your change scene code here and delete the code below
			mat.SetColor("_EmissionColor", Color.yellow);
			SceneManager.LoadScene("MenuScene 1");
			MMReticle.count = 2;
		}
	}

	IEnumerator OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag == "UniqueCollectable") {
			mat.shader = Shader.Find ("Standard");
			col.gameObject.tag = "Untagged";
			col.gameObject.layer = 0;
			mat.SetColor ("_EmissionColor", Color.green);
			yield return new WaitForSeconds (1.5f);
			mat.SetColor ("_EmissionColor", Color.black);
			correctObject++;

		} else if (col.gameObject.tag != "UniqueCollectable") 
		{
			mat.SetColor ("_EmissionColor", Color.red);
			yield return new WaitForSeconds (1.5f);
			mat.SetColor ("_EmissionColor", Color.black);
		}
	}
}
