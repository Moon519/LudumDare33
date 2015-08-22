using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Hide : MonoBehaviour
{
	[SerializeField]
	private SkinnedMeshRenderer meshRenderer;
	private bool canHide;
	private GameObject potentialHidingPlace;

	void Start ()
	{
	
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.A))
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
		this.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	private void RevealPlayer()
	{
		meshRenderer.enabled = true;
	}

	// Detect the potential hiding place 
	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.name);
		if (!canHide && other.gameObject.CompareTag("HidingPlace"))
		{
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
