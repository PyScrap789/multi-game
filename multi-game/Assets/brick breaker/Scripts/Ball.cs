using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public Rigidbody2D rb;

	Brick brick;

	public GameObject brickParticleEffect;

	public float speed = 500f;

	public int health;
	public TextMeshProUGUI healthText;

	private void Start()
	{
		Invoke(nameof(SetRandomTrajectory), 1f);
	}

	private void Update()
	{
		healthText.text = "HEALTH : " + health.ToString();

		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}

	private void SetRandomTrajectory()
	{
		Vector2 force = Vector2.zero;
		force.x = Random.Range(-1f, 1f);
		force.y = -1f;

		rb.AddForce(force.normalized * speed);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Brick"))
		{
			brick = collision.gameObject.GetComponent<Brick>();
			brick.health--;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Respawn Point"))
		{
			health--;
			transform.position = new Vector3(0, 0, 0);
		}
	}
}
