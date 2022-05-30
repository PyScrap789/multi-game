using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
	public int score;
	public int maxScore;

	public string sceneName;

	public bool brickBreakerGame;

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI maxScoreText;

	private void Start()
	{
		maxScoreText.text = PlayerPrefs.GetInt("High Score", 0).ToString();
	}

	private void Update()
	{
		scoreText.text = score.ToString();

		if (score > PlayerPrefs.GetInt("High Score", 0))
		{
			PlayerPrefs.SetInt("High Score", score);
			maxScoreText.text = score.ToString();
		}

		if (brickBreakerGame)
		{
			if(score == 16)
			{
				SceneManager.LoadScene(sceneName);
			}
		}
	}
}
