using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickObject : MonoBehaviour {

	public Transform player;
	public Transform playerCam;
	public Transform onHand;
	private GameObject picking;

	public float throwForce = 10;
	bool hasPlayer = false;
	bool beingCarried = false;
	public AudioClip[] soundToPlay;
	private AudioSource audio;
	public int dmg;
	private bool touched = false;
	public Text pressing;

	void Start()
	{
		audio = GetComponent<AudioSource>();
		picking = GameObject.Find ("Hand");
	}

	void Update()
	{
		float dist = Vector3.Distance(gameObject.transform.position, player.position);
		if (dist <= 1.5f)
		{
			hasPlayer = true;
		}
		else
		{
			hasPlayer = false;
		}
		if (hasPlayer) {
			if (Input.GetButton ("Fire1")) {
				Rigidbody item = GetComponent<Rigidbody> ();
				item.isKinematic = true;
				this.transform.position = onHand.position;
				this.transform.parent = GameObject.Find ("FPSController").transform;
				this.transform.parent = GameObject.Find ("CardboardMain").transform;
				this.transform.parent = GameObject.Find ("Head").transform;
				this.transform.parent = GameObject.Find ("Main Camera").transform;
				this.transform.parent = GameObject.Find ("Hand").transform;
				//Ray ray = new Ray (picking.transform.position, picking.transform.forward);
				//transform.position = ray.GetPoint (1f);

				beingCarried = true;
				pressing.text = "Picked up";
			} 
			else if (Input.GetButton("Fire2")) {
				Rigidbody item = GetComponent<Rigidbody> ();
				this.transform.parent = null;
				item.isKinematic = false;
				pressing.text = "Dropped";
			}
		}
		if (beingCarried)
		{
			if (touched)
			{
				GetComponent<Rigidbody>().isKinematic = false;
				transform.parent = null;
				beingCarried = false;
				touched = false;
			}
			if (Input.GetMouseButtonDown(0))
			{
				GetComponent<Rigidbody>().isKinematic = false;
				transform.parent = null;
				beingCarried = false;
				GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
				RandomAudio();
			}
			else if (Input.GetMouseButtonDown(1))
			{
				GetComponent<Rigidbody>().isKinematic = false;
				transform.parent = null;
				beingCarried = false;
			}
		}
	}
	void RandomAudio()
	{
		if (audio.isPlaying){
			return;
		}
		audio.clip = soundToPlay[Random.Range(0, soundToPlay.Length)];
		audio.Play();

	}
	void OnTriggerEnter()
	{
		if (beingCarried)
		{
			touched = true;
		}
	}
}
