using UnityEngine;
using System.Collections;

public class CollectableItems : MonoBehaviour
{
	[SerializeField]
	private UnityEngine.UI.Text informationTextZone;
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
		informationTextZone.text = "";
		Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerNearBy = true;
			player = other.gameObject;
			informationTextZone.text = "Press E to pick up item";
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
