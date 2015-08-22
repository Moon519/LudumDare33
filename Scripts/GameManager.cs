using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	// Singleton pattern
	public static GameManager Instance;

	void Awake()
	{
		Instance = this;
	}

	public void GameOver()
	{

	}
}
