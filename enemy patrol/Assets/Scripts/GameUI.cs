using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

	public GameObject gameLoseUI;
	public GameObject gameWinUI;
	bool gameIsOver;


	void Start()
	{
		Enemy.OnGuardHasSpottedPlayer += ShowGameLoseUI;
		FindObjectOfType<Playerscript>().OnReachedEndOfLevel += ShowGameWinUI;
	}


	void Update()
	{
		if (gameIsOver)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				SceneManager.LoadScene(0);
			}
		}
	}

	void ShowGameWinUI()
	{
		OnGameOver(gameWinUI);
	}

	void ShowGameLoseUI()
	{
		OnGameOver(gameLoseUI);
	}

	void OnGameOver(GameObject gameOverUI)
	{
		gameOverUI.SetActive(true);
		gameIsOver = true;
		Enemy.OnGuardHasSpottedPlayer -= ShowGameLoseUI;
		FindObjectOfType<Playerscript>().OnReachedEndOfLevel -= ShowGameWinUI;
	}
}