using UnityEngine;
using System.Collections;

public class CollectableItems : MonoBehaviour
{
	private bool playerNearBy = false;
	private GameObject player;

	void Update()
	{
		if (playerNearBy && Input.GetKeyDown(KeyCode.E))
			PickUpObject();
	}

	private void PickUpObject()
	{
		GameManager.Instance.IncreaseCollectedItems();
		Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerNearBy = true;
			player = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (playerNearBy && other.gameObject == player)
		{
			player = null;
			playerNearBy = false;
		}
	}
}
