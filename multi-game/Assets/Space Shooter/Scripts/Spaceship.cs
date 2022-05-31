using System;
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

	public CharacterDatabase characterDatabase;

	public SpriteRenderer artworkSprite;

	public float timeBetweenBulletSpawn;
	public float startTimeBtwSpawn;
	public float decreaseTime;
	public float minTime = 0.65f;

	public int health;

	public TextMeshProUGUI healthText;

	int selectedOption = 0;

	private void Start()
	{
		if (!PlayerPrefs.HasKey("selectedOption"))
		{
			selectedOption = 0;
		}
		else
		{
			Load();
		}

		UpdateCharacter(selectedOption);
	}

	private void Load()
	{
		selectedOption = PlayerPrefs.GetInt("selectedOption");
	}

	private void UpdateCharacter(int selectedOption)
	{
		Character character = characterDatabase.GetCharacter(selectedOption);
		artworkSprite.sprite = character.characterSprite.GetComponent<SpriteRenderer>().sprite;
	}

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
