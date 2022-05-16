using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject firePosition;

	public float timeBetweenBulletSpawn;
	public float startTimeBtwSpawn;
	public float decreaseTime;
	public float minTime = 0.65f;

	public int score;
	public int highScore;
	public int health;

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI highScoreText;
	public TextMeshProUGUI healthText;

	private void Start()
	{
		highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
	}

	private void Update()
	{
		if(health <= 0)
		{
			Destroy(gameObject);
		}

		healthText.text = "HEALTH : " + health.ToString();
		scoreText.text = score.ToString();

		if (timeBetweenBulletSpawn <= 0)
		{
			Instantiate(bulletPrefab, firePosition.transform.position, Quaternion.identity);
			timeBetweenBulletSpawn = startTimeBtwSpawn;

			if (startTimeBtwSpawn > minTime)
			{
				startTimeBtwSpawn -= decreaseTime;
			}
		}
		else
		{
			timeBetweenBulletSpawn -= Time.deltaTime;
		}

		if(score > PlayerPrefs.GetInt("HighScore", 0))
		{
			PlayerPrefs.SetInt("HighScore", score);
			highScoreText.text = score.ToString();
		}
	}
}
