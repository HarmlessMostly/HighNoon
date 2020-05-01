using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D rb;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-3 * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(3 * Time.deltaTime, 0, 0);
		}
		
	}

	private void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			rb.AddForce(Vector2.up * 8, ForceMode2D.Impulse);

		}
	}
}