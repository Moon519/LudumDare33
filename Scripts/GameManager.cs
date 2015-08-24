using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private UnityEngine.UI.Text informationPanel;
	private float timerBackToMainMenu;
	private bool playerLoose = false;

	// Singleton pattern
	public static GameManager Instance;
	private int collectedItems = 0;

	void Awake()
	{
		Instance = this;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update()
	{
		if (playerLoose)
		{
			timerBackToMainMenu -= Time.deltaTime;
			if (timerBackToMainMenu < 0f)
				Application.LoadLevel(0);
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel(1);
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(0);
		}
	}

	public void IncreaseCollectedItems()
	{
		collectedItems++;
	}

	public void PlayerWin()
	{
		informationPanel.text = "You just reached the win zone with " + collectedItems + " items!";
		if (collectedItems == 10)
		{
			informationPanel.text += "\n You got them all and just finished the game, congratz!";
			timerBackToMainMenu = 6;
			playerLoose = true;
		}
		else
		{
			informationPanel.text += "\n You didn't collect them all, try again!";
			timerBackToMainMenu = 4;
			playerLoose = true;
		}
	}

	public void GameOver()
	{
		informationPanel.text = "A Villager just catched you! You loose!";
		timerBackToMainMenu = 2;
		playerLoose = true;
    }
}