using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiscript : MonoBehaviour {

	NavMeshAgent agent;
	public Transform target;

	public float alertDistance;

	private int destPoint = 0;
	public Transform[] points;
	public float patrolSpeed = 0.4f;
	public float chaseSpeed = 1.7f;

 	Animator ai_Animator;
	bool isEngaging; 
	bool isAttacking;
	public float attackDistance;

	public AudioSource patrol;
	public AudioSource scream;
	public AudioSource growl;
	bool check_play = true;

	void Start () 
	{
		ai_Animator = gameObject.GetComponentInChildren <Animator> ();
		isEngaging = false;
		isAttacking = false;

		agent = GetComponent<NavMeshAgent> ();


		agent.autoBraking = false;

		GotoNextPoint ();
	}


	void Update () 
	{
		//Chase
		if (Vector3.Distance (target.position, transform.position) < alertDistance) {
			agent.speed = chaseSpeed;
			isEngaging = true;
			if (check_play == true) {
				scream.Play ();
				growl.Play ();
				patrol.Stop ();
				check_play = false;
			}

			agent.SetDestination (target.position);
		}
		//patrol
		else if (!agent.pathPending && agent.remainingDistance < 0.5f) {
			agent.speed = patrolSpeed;
			isEngaging = false;
			if (check_play == false) {
				patrol.Play ();
				scream.Stop ();
				growl.Stop ();
				check_play = true;
			}
			GotoNextPoint ();
			}

		if (isEngaging == false) 
		{
			ai_Animator.SetBool ("isEngaging", false);
		}

		if (isEngaging == true) 
		{
			ai_Animator.SetBool ("isEngaging", true);

		}

		{
			if (Vector3.Distance (target.position, transform.position) < attackDistance) 
			{
				ai_Animator.SetBool ("isAttacking", true);
			} 
			else 
			{
				ai_Animator.SetBool ("isAttacking", false);
			}
		}

	}

	void GotoNextPoint () {
		if (points.Length == 0) {
			return;
		}

		agent.destination = points [destPoint].position;

		//destPoint = (destPoint + 1) % points.Length;
		destPoint = Random.Range(0, points.Length);
	}
		
}



