using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
	[SerializeField]
	private UnityEngine.UI.Text informationTextZone;
	[SerializeField]
	private GameObject destinationTeleporter;

	private bool playerNearBy = false;
	private GameObject player;

	void Update ()
	{
		if (playerNearBy && Input.GetKeyDown(KeyCode.E))
			TeleportPlayer();
	}

	private void TeleportPlayer()
	{
		player.transform.position = destinationTeleporter.transform.position;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerNearBy = true;
			player = other.gameObject;
			informationTextZone.text = "Press E to Teleport";
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
