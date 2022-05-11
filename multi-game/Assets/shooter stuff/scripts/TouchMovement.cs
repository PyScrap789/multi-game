using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
	public float moveSpeed;

	private void Update()
	{
		TouchMove();
	}

	void TouchMove()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if(mousePos.x > 1)
			{
				transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
			}
			else
			{
				transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
			}
		}
	}
}
