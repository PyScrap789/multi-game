using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed;

	public Spaceship player;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Spaceship>();
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
			player.health -= 1;
			Destroy(gameObject);
		}

		if (collision.CompareTag("Bullet"))
		{
			player.score++;
			Destroy(gameObject);
		}
	}
}
