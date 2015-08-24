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
	}

	public void IncreaseCollectedItems()
	{
		collectedItems++;
	}

	public void PlayerWin()
	{
		informationPanel.text = "You just reached the win zone with " + collectedItems + " items!";
		if (collectedItems == 10)
			informationPanel.text += "\n You got them all and just finished the game, congratz!";
		else
			informationPanel.text += "\n You didn't collect all the items, try again!";
	}

	public void GameOver()
	{
		informationPanel.text = "A Villager just catched you! You loose!";
		timerBackToMainMenu = 3;
		playerLoose = true;
    }
}
