using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;

public class PatrollingAI : AI
{
	[Header("Moving Settings")]
	[SerializeField]
	private List<Vector3> patrollingPositions;

	// Private variables
	private int nextPosition;
	private NavMeshAgent navMeshAgent;
	private bool timerStarted = false;
	private float timerNewPosition;
	private bool trackStarted = false;
	private float timerTrack;
	private GameObject trackedObject;

	void Start ()
	{
		// Position 0 is the starting one
		nextPosition = 1;
		navMeshAgent = this.GetComponent<NavMeshAgent>();
		navMeshAgent.acceleration = acceleration;
		navMeshAgent.speed = movingSpeed;
		warningText.SetActive(false);
		this.GetComponent<SphereCollider>().radius = awareness;

		MoveToNextPosition();
	}
	
	void Update ()
	{
		if (!trackStarted)
		{
			if (!timerStarted && navMeshAgent.velocity.magnitude < 1f)
			{
				timerStarted = true;
				timerNewPosition = Time.realtimeSinceStartup + 2f;
			}
			if (timerStarted && timerNewPosition - Time.realtimeSinceStartup < 0f)
				MoveToNextPosition();
		}
		else
		{
			if (timerTrack - Time.realtimeSinceStartup < 0f)
				GameManager.Instance.GameOver();
			if (trackedObject.GetComponent<ThirdPersonUserControl>().isHiding)
				RestoreLastPath();
		}
	}

	private void MoveToNextPosition()
	{
		navMeshAgent.SetDestination(patrollingPositions[nextPosition]);
		timerStarted = false;
		nextPosition++;
		if (nextPosition >= patrollingPositions.Count)
			nextPosition = 0;
	}

	private void StartTracking(Vector3 dest)
	{
		navMeshAgent.destination = dest;
		timerTrack = Time.realtimeSinceStartup + timeBeforeLoose;
		trackStarted = true;
		warningText.SetActive(true);
	}

	private void RestoreLastPath()
	{
		warningText.SetActive(false);
		trackedObject = null;
		trackStarted = false;

		// Restore the last path
		nextPosition--;
		if (nextPosition < 0)
			nextPosition = patrollingPositions.Count - 1;
		MoveToNextPosition();
	}

	void OnTriggerEnter(Collider other)
	{
		if (!trackStarted && other.gameObject.CompareTag("Player"))
		{
			trackedObject = other.gameObject;
			StartTracking(other.gameObject.transform.position);
        }
	}

	void OnTriggerExit(Collider other)
	{
		if (trackStarted && other.gameObject.CompareTag("Player"))
		{
			RestoreLastPath();
        }
	}
}