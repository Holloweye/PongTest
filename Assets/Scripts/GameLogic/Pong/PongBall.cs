using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour 
{
	private SpriteRenderer rendering;
	private Rigidbody2D ball;
	private float angle;
	private float velocity;

	public Color color = Color.white;

	public delegate void OnCollision();
	public OnCollision onCollision;

	public delegate void OnLeaveGameArea();
	public OnLeaveGameArea onLeaveGameArea;

	public delegate void OnExit();
	public OnExit onExit;

	public void Kill()
	{
		Destroy (gameObject);
	}

	void Start () 
	{
		this.rendering = GetComponent<SpriteRenderer> ();
		this.ball = GetComponent<Rigidbody2D> ();
		this.angle = ((float)Random.Range(0, 360)).radians();
		this.velocity = 3f;
	}
	
	void FixedUpdate () 
	{
		this.ball.position = this.ball.position.add (this.angle.bearing().multiply(this.velocity * Time.deltaTime));
		if (!Camera.main.inViewport(this.ball.position))
		{
			this.onExit();
		}
		else if ((new Vector2()).distance(this.ball.position) > 5.1f) 
		{
			this.onLeaveGameArea();
		}
	}

	void Update()
	{
		this.rendering.color = color;
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

		this.angle = r.radians();
		this.velocity += 1.5f / velocity;
		this.onCollision();
	}
}
