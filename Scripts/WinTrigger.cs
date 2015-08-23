using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour
{
	private bool playerWin = false;

	void OnTriggerEnter(Collider other)
	{
		if (!playerWin && other.gameObject.CompareTag("Player"))
		{
			playerWin = true;
			GameManager.Instance.PlayerWin();
		}
	}
}
