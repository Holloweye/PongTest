using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour 
{
	public float life;
	private float counter = 0f;
	private SpriteRenderer rendering;

	void Start()
	{
		this.rendering = GetComponent<SpriteRenderer> ();
	}

	void Update () 
	{
		this.counter += Time.deltaTime;

		if (this.counter >= this.life) {
			Destroy (this.gameObject);
		} else {
			this.rendering.color = new Vector4(
				this.rendering.color.r,
				this.rendering.color.g,
				this.rendering.color.b,
				1f - this.counter / this.life
			);
		}
	}
}
