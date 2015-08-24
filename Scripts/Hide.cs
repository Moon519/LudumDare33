using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Hide : MonoBehaviour
{
	[SerializeField]
	private UnityEngine.UI.Text informationTextZone;
	[SerializeField]
	private SkinnedMeshRenderer meshRenderer;
	private bool canHide;
	private GameObject potentialHidingPlace;
	private Vector3 previousPosition;

	void Start ()
	{
	
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (this.GetComponent<ThirdPersonUserControl>().isHiding)
			{
				RevealPlayer();
				this.GetComponent<ThirdPersonUserControl>().isHiding = false;
			}
			else if (canHide)
			{
				HidePlayer();
				this.GetComponent<ThirdPersonUserControl>().isHiding = true;
			}
		}
	}

	private void HidePlayer()
	{
		meshRenderer.enabled = false;
		previousPosition = this.transform.position;
		this.transform.position = potentialHidingPlace.GetComponent<HidingPlace>().hidingPosition;
	}

	private void RevealPlayer()
	{
		meshRenderer.enabled = true;
		this.transform.position = previousPosition;
	}

	// Detect the potential hiding place 
	void OnTriggerEnter(Collider other)
	{
		if (!canHide && other.gameObject.CompareTag("HidingPlace"))
		{
			informationTextZone.text = "Press E to Hide";
			potentialHidingPlace = other.gameObject;
			canHide = true;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (!canHide && other.gameObject.CompareTag("HidingPlace"))
		{
			potentialHidingPlace = other.gameObject;
			canHide = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (canHide && other.gameObject == potentialHidingPlace)
		{
			informationTextZone.text = "";
			potentialHidingPlace = null;
			canHide = false;
		}
	}

	// Getter & Setter
	public bool isHiding()
	{
		return this.GetComponent<ThirdPersonUserControl>().isHiding;
	}
}
