using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed;

	Spaceship spaceship;
	ScoreManager scoreManager;

	public GameObject explosionSound;
	public GameObject particleEffect;

	private void Awake()
	{
		spaceship = GameObject.FindGameObjectWithTag("Player").GetComponent<Spaceship>();
		scoreManager = GameObject.FindGameObjectWithTag("Score Manager").GetComponent<ScoreManager>();
	}

	private void Update()
	{
		transform.Translate(Vector2.down * speed * Time.deltaTime);
		Destroy(gameObject, 15);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			spaceship.health -= 1;
			Destroy(gameObject);
		}

		if (collision.CompareTag("Bullet"))
		{
			scoreManager.score++;
			Instantiate(explosionSound, transform.position, Quaternion.identity);
			Instantiate(particleEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
