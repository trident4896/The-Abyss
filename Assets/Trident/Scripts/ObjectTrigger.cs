using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour {

	public Rigidbody item;
	public int count = 40;
	public AudioSource drop;

	// Use this for initialization
	void Start () {
		item.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (count == 0) {
			item.isKinematic = false;
			drop.Play ();
		}
	}

	void OnTriggerExit() {
		count--;
	}


}

