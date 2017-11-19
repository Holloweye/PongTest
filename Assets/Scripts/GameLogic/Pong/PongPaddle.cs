using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPaddle : MonoBehaviour
{
	private Rigidbody2D paddle;
	private SpriteRenderer rendering;

	private float angle;
	public Player player;

	void Start ()
	{
		paddle = GetComponent<Rigidbody2D> ();
		rendering = GetComponent<SpriteRenderer> ();
		angle = 0f;
	}

	void FixedUpdate ()
	{
		if (player.controller.isStickOverThreshold (
			     JoystickAxis.RIGHT_STICK_X,
			     JoystickAxis.RIGHT_STICK_Y,
			     0.1f)) 
		{
			var origin = new Vector2 ();
			angle = origin.angle (new Vector2 (
				player.controller.getAxis (JoystickAxis.RIGHT_STICK_X), 
				-player.controller.getAxis (JoystickAxis.RIGHT_STICK_Y)));
		}

		paddle.position = angle.bearing ().multiply (5.0f);
		paddle.rotation = angle.degrees () + 90f;
	}

	void Update ()
	{
		if (player != null) {
			rendering.color = player.color;
		}
	}

	public void Kill ()
	{
		Destroy (this.gameObject);
	}
}
