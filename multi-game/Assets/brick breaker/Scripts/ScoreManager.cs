using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public int score;
	public int maxScore;

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
	}
}
