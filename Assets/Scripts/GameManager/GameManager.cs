using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	public PlayerHealth playerHealth;
	public Transform playerTransform;
	public GameOver gameOver;

	private void Awake()
	{
		// Đảm bảo chỉ có 1 instance
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject); // Nếu muốn giữ qua scene
		}
		else
		{
			Destroy(gameObject);
			return;
		}
	}

	public bool IsPlayerAlive()
	{
		return playerHealth != null && !playerHealth.isDead;
	}

	public void TriggerGameOver()
	{
		gameOver.Setup();
	}
}
