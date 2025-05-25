using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	[SerializeField] private GameObject gameOverUI;
	[SerializeField] private Text finalScoreText;

	public void Setup()
	{
		gameOverUI.SetActive(true);

		float finalScore = GameManager.Instance.playerHealth.score;
		finalScoreText.text = "Your score: " + finalScore.ToString("0");

		Time.timeScale = 0f; // Dừng game
	}

	public void RestartButton()
    {
		Time.timeScale = 1f;
		Destroy(GameManager.Instance.gameObject);
		SceneManager.LoadScene("PlayGame");
    }

    public void ExitButton()
    {
		Time.timeScale = 1f;
		SceneManager.LoadScene("Start");
    }
}
