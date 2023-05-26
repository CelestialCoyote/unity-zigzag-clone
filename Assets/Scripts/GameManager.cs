using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool gameStarted;
	public int score;
	public Text scoreText;
	public Text highScoreText;

	private void Awake()
	{
		highScoreText.text = "High Score: " + GetHighScore().ToString();
	}

	public void StartGame()
	{
		gameStarted = true;
		FindObjectOfType<Road>().StartBuilding();
	}

	public void EndGame()
	{
		SceneManager.LoadScene(0);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
			StartGame();
	}

	public void IncreaseScore()
	{
		score++;
		scoreText.text = score.ToString();

		if (score > GetHighScore())
		{
			PlayerPrefs.SetInt("HighScore", score);
			highScoreText.text =  "High Score: " + score.ToString();
		}
	}

	public int GetHighScore()
	{
		int i = PlayerPrefs.GetInt("HighScore");

		return i;
	}
}
