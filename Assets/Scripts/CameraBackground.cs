using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackground : MonoBehaviour 
{
	private float spawnRate = 0.1f;
	private float spawnCounter = 0f;
	private float time = 0f;
	private float life = 3f;

	private float sScale;
	private float eScale;
	private float sRotation;
	private float eRotation;
	private float angle;
	private float speed;
	private float sR, sG, sB;
	private float eR, eG, eB;
	private float sA = 1f;
	private float eA = 0f;
	private float sX, sY;

	void Update () 
	{
		spawnCounter += Time.deltaTime;
		time += Time.deltaTime;

		sRotation = alg(time + 100f) * 360f;
		eRotation = alg(time + 500f) * 360f;
		sScale = 	alg(time + 1000f) + 3f;
		eScale = 	alg(time + 1500f) * 2f;
		angle = 	(alg(time + 2000f) * 360f).radians();
		speed = 	alg(time + 2500f) * 3f;

		sR = alg (time + 3000f) / 2f + 0.5f;
		sG = alg (time + 3500f) / 2f + 0.5f;
		sB = alg (time + 4000f) / 2f + 0.5f;

		eR = alg (time + 4500f) / 2f + 0.5f;
		eG = alg (time + 5000f) / 2f + 0.5f;
		eB = alg (time + 5500f) / 2f + 0.5f;

		sX = (alg (time + 6000f) - 0.5f) * 2f;
		sY = (alg (time + 6500f) - 0.5f) * 2f;

		if (spawnCounter >= spawnRate) {

			var square = (GameObject)Instantiate(Resources.Load ("square"));
			square.transform.position = new Vector3 (sX, sY, 0f);

			var anim = square.GetComponent<BgAnim> ();
			anim.fromScale = sScale;
			anim.toScale = eScale;
			anim.fromRotation = sRotation;
			anim.toRotation = eRotation;
			anim.angle = angle.bearing();
			anim.speed = speed;
			anim.fromColor = new Color (sR, sG, sB, sA);
			anim.toColor = new Color (eR, eG, eB, eA);
			anim.life = life;
			anim.fromLife = life;
			anim.updateColor ();
			anim.updatePosition ();

			spawnCounter = 0f;
		}
	}

	private float alg(float x)
	{
		return Perlin.Noise (x / 10f);
	}
}
