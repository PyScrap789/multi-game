using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed;

	public Player playerReference;

	private void Awake()
	{
		playerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	private void Update()
	{
		transform.Translate(Vector2.down * speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			playerReference.health -= 1;
			Destroy(gameObject);
			Debug.Log("destroyed");
		}

		if (collision.CompareTag("Bullet"))
		{
			Destroy(gameObject);
			Debug.Log("destroyed");
		}
	}
}
