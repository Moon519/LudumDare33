using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	void Start ()
	{
		// Position 0 is the starting one
		nextPosition = 1;
		navMeshAgent = this.GetComponent<NavMeshAgent>();
		navMeshAgent.acceleration = acceleration;
		navMeshAgent.speed = movingSpeed;
		warningText.SetActive(false);

		MoveToNextPosition();
	}
	
	void Update ()
	{
		if (!timerStarted && navMeshAgent.velocity.magnitude < 1f)
		{
			timerStarted = true;
			timerNewPosition = Time.realtimeSinceStartup + 2f;
        }
		if (timerStarted && timerNewPosition - Time.realtimeSinceStartup < 0f)
			MoveToNextPosition();
	}

	private void MoveToNextPosition()
	{
		navMeshAgent.SetDestination(patrollingPositions[nextPosition]);
		timerStarted = false;
		nextPosition++;
		if (nextPosition >= patrollingPositions.Count)
			nextPosition = 0;
	}
}