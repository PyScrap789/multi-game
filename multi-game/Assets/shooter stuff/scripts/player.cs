using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody2D rb;
	public GameObject bulletPrefab;
	public GameObject firePosition;

	float distY;
	float distZ;
	bool isDragging = false;
	Vector3 offset;
	Transform toDrag;

	public int health;

	private void Update()
	{

		if (Input.GetMouseButtonDown(0))
		{
			Instantiate(bulletPrefab, firePosition.transform.position, Quaternion.identity);
		}

		if(health <= 0)
		{
			Destroy(gameObject);
		}

		Vector3 v3;

		if(Input.touchCount != 1)
		{
			isDragging = false;
			return;
		}

		Touch touch = Input.touches[0];
		Vector3 pos = touch.position;

		if(touch.phase == TouchPhase.Began)
		{
			Ray ray = Camera.main.ScreenPointToRay(pos);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit))
			{
				if(hit.collider.tag == "Player")
				{
					toDrag = hit.transform;
					distY = hit.transform.position.y - Camera.main.transform.position.y;
					distZ = hit.transform.position.z - Camera.main.transform.position.z;
					v3 = new Vector3(pos.x, distY, distZ);
					v3 = Camera.main.ScreenToWorldPoint(v3);
					offset = toDrag.position - v3;
					isDragging = true;
				}
			}
		}

		if (isDragging && touch.phase == TouchPhase.Moved)
		{
			v3 = new Vector3(Input.mousePosition.x, distY, distZ);
			v3 = Camera.main.ScreenToViewportPoint(v3);
			toDrag.position = v3 + offset;
		}

		if(isDragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
		{
			isDragging = false;
		}
	}
}
