using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatrollingAI : AI
{
	[Header("Moving Settings")]
	[SerializeField]
	private bool canMove;
	[SerializeField]
	private float patrollingSpeed;
	[SerializeField]
	private List<Vector3> patrollingPositions;

	void Start ()
	{
	
	}
	
	void Update ()
	{
	
	}
}
