using UnityEngine;
using System.Collections;

public class MainMenuEvents : MonoBehaviour
{
	void Start()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void PlayButtonEvent()
	{
		Application.LoadLevel(1);
	}
}
