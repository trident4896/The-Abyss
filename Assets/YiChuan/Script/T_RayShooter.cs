using UnityEngine;
using System.Collections;

//This function is used for raycast detection
public class T_RayShooter : MonoBehaviour {

	Camera cam;
	bool lockCamera = true;
	private float detectionDistance = 1.5f;
	bool isDoorOpen = false;

	public AudioSource[] doorSounds;
	AudioSource openDoorsfx;
	AudioSource closeDoorsfx;

	void Start () {
		cam = GetComponent<Camera> ();
		doorSounds = GetComponents<AudioSource> ();
		openDoorsfx = doorSounds [0];
		closeDoorsfx = doorSounds [1];
	}

	void Update () {

		if (Input.GetMouseButtonDown (0)) 
		{
			Vector3 screenCentre = new Vector3 (cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
			Ray ray = cam.ScreenPointToRay (screenCentre);
			RaycastHit hit;

			Debug.DrawRay (ray.origin, ray.direction * 100, Color.red, 2);

			if(Physics.Raycast(ray, out hit))
			{
				GameObject door = hit.transform.gameObject;
	//			T_DoorRotation jailDoor = door.GetComponent<T_DoorRotation> ();

				//Jaildoor detection
	//			if (jailDoor != null) 
				{
					if(hit.distance <= detectionDistance)
					{
						if (isDoorOpen == false) 
						{
	//						jailDoor.RotateDoor (jailDoor.openAngle);
							openDoorsfx.Play ();
							isDoorOpen = true;
						} 
						else if (isDoorOpen == true) 
						{
	//						jailDoor.RotateDoor (-jailDoor.openAngle);
							closeDoorsfx.Play ();
							isDoorOpen = false;
						}
					}
				}
				//=========================================================================
				//Previously this part is used for collecting gems

				//GameObject hitObject = hit.transform.gameObject;
				//T_GlowingGem glowingGems = hitObject.GetComponent<T_GlowingGem> ();

				//T_EventManager eventManager;	
				//eventManager = FindObjectOfType<T_EventManager> ();

				//if (glowingGems != null) {
				//	if (hit.distance <= detectionDistance) {
						//eventManager.DecreaseCount();
						//glowingGems.onHeld();
						//glowingGems.orbHitted ();
				//	}
				//}
				//=========================================================================

				//=========================================================================
				//This part is use for destroying the props, but later the plan had changed

				//else 
					//if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Destructable")) 
				//{
				//	StartCoroutine (SphereIndicator (hit.point));
				//}
				//=========================================================================
			}
		}
			
		//lock the cursor to the screen
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			lockCamera = !lockCamera;
		}

		if (lockCamera == true) 
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		if (lockCamera == false) 
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

	//Draw an * on the middle of the UI
	public void OnGUI()
	{
		int size = 12;
		float posX = cam.pixelWidth / 2 - size / 4;
		float posY = cam.pixelHeight / 2 - size / 4;
		GUI.Label (new Rect (posX, posY, size, size), "*");
	}

	//Create a sphere on where the ray hit
	IEnumerator SphereIndicator (Vector3 point)
	{
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.position = point;
		sphere.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
		yield return new WaitForSeconds(1);
		Destroy (sphere);
	}
}