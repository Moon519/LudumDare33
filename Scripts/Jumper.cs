using UnityEngine;
using System.Collections;

public class Jumper : MonoBehaviour
{
	[SerializeField]
	private UnityEngine.UI.Text informationTextZone;
	[SerializeField]
	private float forwardForce;
	[SerializeField]
	private float verticalForce;

	private bool playerNearBy = false;
	private GameObject player;

	void Update()
	{
		if (playerNearBy && Input.GetKeyDown(KeyCode.E))
			JumpPlayer();
	}

	private void JumpPlayer()
	{
		player.GetComponent<Rigidbody>().AddRelativeForce(0f, verticalForce, 0f);
		player.GetComponent<Rigidbody>().AddRelativeForce(0f, 0f, forwardForce);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerNearBy = true;
			player = other.gameObject;
			informationTextZone.text = "Press E to Jump";
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (playerNearBy && other.gameObject == player)
		{
			player = null;
			playerNearBy = false;
			informationTextZone.text = "";
		}
	}
}
