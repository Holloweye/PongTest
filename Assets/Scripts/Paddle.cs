using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour 
{
	private Rigidbody2D paddle;
	private SpriteRenderer rendering;

	private float angle;
	public Player player;

	void Start()
	{
		paddle = GetComponent<Rigidbody2D> ();
		rendering = GetComponent<SpriteRenderer> ();
		angle = 0f;
	}

	void FixedUpdate()
	{
		if (player != null && player.controller != null) {
			var x = player.controller.getAxis (JoystickAxis.RIGHT_STICK_X);
			var y = 0f - player.controller.getAxis (JoystickAxis.RIGHT_STICK_Y);

			if (x <= -0.1f || x >= 0.1f || y <= -0.1f || y >= 0.1f)
			{
				var origin = new Vector2 ();
				angle = origin.angle (new Vector2 (x, y));
			}
		}

		paddle.position = angle.bearing().multiply(5.0f);
		paddle.rotation = angle.degrees() + 90f;
	}

	void Update()
	{
		if (player != null) {
			rendering.color = player.color;
		}
	}
}
