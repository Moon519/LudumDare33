using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	// Singleton pattern
	public static GameManager Instance;
	private int collectedItems = 0;

	void Awake()
	{
		Instance = this;
	}

	public void IncreaseCollectedItems()
	{
		collectedItems++;
	}

	public void PlayerWin()
	{

	}

	public void GameOver()
	{
		Debug.Log("!!! Game Over !!!");
	}
}
