using UnityEngine;
using System.Collections;

public class MainMenuEvents : MonoBehaviour
{
	void Start()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	public void PlayButtonEvent()
	{
		Application.LoadLevel(1);
	}
}
