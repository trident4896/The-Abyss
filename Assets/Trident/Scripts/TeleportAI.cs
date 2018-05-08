using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeleportAI : MonoBehaviour {


	public GameObject EnemyAI;
	bool AiOnScene = true;

	//public Transform[] spawnPoints;
	//private int spawnLocation = 0;


	//public GameObject[] spawnPoint;
	//private int spawnLocation = 0;

	void Start() {

		//SpawnEnemy ();

		//spawnLocation = Random.Range (1, spawnPoint.Length);
		//EnemyAI.transform.position = spawnPoint[spawnLocation].transform.position;

	}

	void Update()
	{
		if (AiOnScene == true) {
			float RandomTime = Random.Range (20, 25);
			Invoke ("DisableAi", RandomTime);
		} else if (AiOnScene == false) {
			float RandomTime = Random.Range (30, 50);
			Invoke ("EnableAi", RandomTime);
		}
	}

	void DisableAi()
	{
		//EnemyAI.GetComponent<NavMeshAgent> ().enabled = false;
		EnemyAI.SetActive(false);
		AiOnScene = false;
		CancelInvoke ();
	}

	void EnableAi()
	{
		//EnemyAI.GetComponent<NavMeshAgent> ().enabled = true;
		EnemyAI.SetActive(true);
		AiOnScene = true;
		CancelInvoke ();
	}

	/*public void SpawnEnemy() {
		spawnLocation = Random.Range (0, spawnPoints.Length);

		Vector3 pos = spawnPoints [spawnLocation].position;

		Instantiate (EnemyAI, pos, Quaternion.identity);
	}*/
}
