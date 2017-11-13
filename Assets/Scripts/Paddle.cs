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
			if (player.controller.getType () == InputType.Directional) {
				var origin = new Vector2 (0, 0);
				angle = origin.angle (player.controller.direction ());
			} else if (player.controller.getType () == InputType.Key) {
				if (player.controller.left ())
					angle += 1.0f * Time.deltaTime * (player.controller.boost () ? 5.0f : 1.0f);

				if (player.controller.right ())
					angle -= 1.0f * Time.deltaTime * (player.controller.boost () ? 5.0f : 1.0f);
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
