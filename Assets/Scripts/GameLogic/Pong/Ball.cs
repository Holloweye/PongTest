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
		velocity = 1f;
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

		const float limitAngle = 40f;
		var angleOfHit = ball.position.angle (paddle.position).degrees () + 180f;
		var angleOfPaddle = paddle.rotation + 90f;
		var angleDiff = (angleOfHit - angleOfPaddle + 180f + 360f) % 360f - 180f;

		var finalAngle = angleOfHit;

		if (angleDiff >= limitAngle) {
			finalAngle -= (angleDiff - limitAngle);
		} else if (angleDiff <= -limitAngle) {
			finalAngle -= (angleDiff + limitAngle);
		}

		angle = (finalAngle).radians();
		velocity += 0.1f;
		onCollision();
	}
}
