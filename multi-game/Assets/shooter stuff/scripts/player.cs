using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	float speed = 5f;

	public Rigidbody2D rb;
	public GameObject bulletPrefab;
	public GameObject firePosition;

	public int health;

	Vector2 movement;

	private void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");

		if (Input.GetMouseButtonDown(0))
		{
			Instantiate(bulletPrefab, firePosition.transform.position, Quaternion.identity);
		}

		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
	}
}
