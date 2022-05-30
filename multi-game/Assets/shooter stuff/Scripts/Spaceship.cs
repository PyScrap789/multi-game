using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject firePosition;
	public GameObject gameOverScreen;
	public GameObject spawner;

	public float timeBetweenBulletSpawn;
	public float startTimeBtwSpawn;
	public float decreaseTime;
	public float minTime = 0.65f;

	public int health;

	public TextMeshProUGUI healthText;

	private void Update()
	{
		if(health <= 0)
		{
			gameOverScreen.SetActive(true);
			Destroy(spawner);
			Destroy(gameObject);
		}

		healthText.text = "HEALTH : " + health.ToString();

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
	}
}
