using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public int score;
	public int highScore;

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI highScoreText;

	private void Start()
	{
		highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
	}

	private void Update()
	{
		scoreText.text = score.ToString();

		if (score > PlayerPrefs.GetInt("HighScore", 0))
		{
			PlayerPrefs.SetInt("HighScore", score);
			highScoreText.text = score.ToString();
		}
	}
}
