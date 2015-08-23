using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour
{
	// Settings
	[Header("General Settings")]
	[SerializeField]
	protected float awareness;
	[SerializeField]
	protected float movingSpeed;
	[SerializeField]
	protected float acceleration;
	[SerializeField]
	protected float reactionTime;
	[SerializeField]
	protected float timeBeforeLoose;

	[Header("UI Settings")]
	[SerializeField]
	protected GameObject warningText;
}