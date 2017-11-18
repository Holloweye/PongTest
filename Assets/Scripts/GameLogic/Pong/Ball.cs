using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{
	private SpriteRenderer rendering;
	private Rigidbody2D ball;
	private float angle;
	private float velocity;

	public Color color = Color.white;

	public delegate void OnCollision();
	public OnCollision onCollision;

	public delegate void OnExit();
	public OnExit onExit;

	public void Kill()
	{
		Destroy (gameObject);
	}

	void Start () 
	{
		rendering = GetComponent<SpriteRenderer> ();
		ball = GetComponent<Rigidbody2D> ();
		angle = ((float)Random.Range(0, 360)).radians();
		velocity = 3f;
	}
	
	void FixedUpdate () 
	{
		ball.position = ball.position.add (angle.bearing().multiply(velocity * Time.deltaTime));

		var origin = new Vector2 (0, 0);
		if (origin.distance (ball.position) > 6) {
			onExit ();
		}
	}

	void Update()
	{
		rendering.color = color;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		var paddle = collision.gameObject.GetComponent<Rigidbody2D> ();

		/*
			https://math.stackexchange.com/questions/1844/how-to-calculate-reflected-light-angle

			x = angle of paddle
			z = angle of ball
			r = new angle of ball

			z' = 180 - z
			a = 180 - (x + z')
			r = -(a - x)

			one line:
			r = -((180 - (x + (180 - z))) - x)
		*/

		var x = paddle.rotation + 90f;
		var z = angle.degrees();
		var zi = 180f - z;
		var a = 180f - (x + zi);
		var r = -(a - x) - 180f;
		angle = r.radians();

		velocity += 1.5f / velocity;
		onCollision();
	}
}
