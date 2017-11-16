using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgAnim : MonoBehaviour 
{
	public float fromScale;
	public float toScale;
	public float fromRotation;
	public float toRotation;
	public Vector2 angle;
	public float speed;
	public Color fromColor;
	public Color toColor;
	public float fromLife;
	public float life;

	private SpriteRenderer rendering;

	void Update () 
	{
		life -= Time.deltaTime;
		if (life <= 0f) {
			Destroy (this.gameObject);
		} else {
			updateColor ();
		}
	}

	void FixedUpdate()
	{
		updatePosition ();
	}

	public void updateColor()
	{
		if (rendering == null) {
			rendering = GetComponent<SpriteRenderer> ();
		}

		float p = getP ();
		float r = fromColor.r + (toColor.r - fromColor.r) * p;
		float g = fromColor.g + (toColor.g - fromColor.g) * p;
		float b = fromColor.b + (toColor.b - fromColor.b) * p;
		float a = fromColor.a + (toColor.a - fromColor.a) * p;
		rendering.color = new Color (r, g, b, a);
	}

	public void updatePosition()
	{
		float p = getP ();
		float scale = fromScale + (toScale - fromScale) * p;
		float rotation = fromRotation + (toRotation - fromRotation) * p;

		transform.localScale = new Vector3 (scale, scale, 1f);
		transform.eulerAngles = new Vector3 (0f, 0f, rotation);

		transform.position = new Vector3 (
			transform.position.x + angle.x * speed * Time.deltaTime,
			transform.position.y + angle.y * speed * Time.deltaTime,
			0f
		);
	}

	private float getP()
	{
		if (life <= 0f) {
			return 0f;
		}
		return 1f - life / fromLife;
	}
}
