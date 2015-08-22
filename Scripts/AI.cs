using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour
{
	// Settings
	[Header("General Settings")]
	[SerializeField]
	private float awareness;
	[SerializeField]
	private float reactionTime;
	[SerializeField]
	private float movingSpeed;

	[Header("Moving Settings")]
	[SerializeField]
	private bool canMove;
	[SerializeField]
	private float patrollingSpeed;
	[SerializeField]
	private List<Vector3> patrollingPositions;

	// Private variables
	private Vector3 lastPlayerPosition;

	void Update()
	{

	}

	void OnTriggerEnter(Collider other)
	{

	}
}