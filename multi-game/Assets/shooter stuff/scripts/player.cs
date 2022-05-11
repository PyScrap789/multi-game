using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody2D rb;
	public GameObject bulletPrefab;
	public GameObject firePosition;

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
			Destroy(gameObject);
		}

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

		healthText.text = "HEALTH - " + health.ToString();
	}
}
