using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
	public int health;
	public bool randomHealth;

	public ScoreManager scoreManager;

	public GameObject brickParticleEffect;
	//public GameObject brickDestroySound;

	SpriteRenderer spriteRenderer;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		if(randomHealth == true)
		{
			health = Random.Range(1, 5);
		}
	}

	private void Update()
	{
		if (health <= 0)
		{
			scoreManager.score++;
			Instantiate(brickParticleEffect, transform.position, Quaternion.identity);
			//Instantiate(brickDestroySound, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		else if (health == 1)
		{
			spriteRenderer.color = new Color(255, 0, 0);
		}
		else if (health == 2)
		{
			spriteRenderer.color = new Color(255, 255, 0);
		}
		else if (health == 3)
		{
			spriteRenderer.color = new Color(0, 255, 0);
		}
		else if (health == 4)
		{
			spriteRenderer.color = new Color(0, 0, 255);
		}
	}
}
