using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackground : MonoBehaviour 
{
	private float spawnRate = 0.1f;
	private float spawnCounter = 0f;

	private float sScale;
	private float eScale;
	private float sRotation;
	private float eRotation;
	private float angle;
	private float speed;
	private float sR, sG, sB;
	private float eR, eG, eB;
	private float life;

	void Start () 
	{
		sScale = 3f;
		eScale = 0f;

		sRotation = 0f;
		eRotation = 180f;

		angle = 90f;
		speed = 1f;

		sR = 255f;
		sG = 0f;
		sB = 0f;

		eR = 0f;
		eG = 0f;
		eB = 255f;

		life = 3f;
	}
	
	void Update () 
	{
		spawnCounter += Time.deltaTime;
		if (spawnCounter >= spawnRate) {

			var square = (GameObject)Instantiate(Resources.Load ("square"));
			square.transform.position = new Vector3 (0f, 0f, 0f);

			var anim = square.GetComponent<BgAnim> ();
			anim.fromScale = sScale;
			anim.toScale = eScale;
			anim.fromRotation = sRotation;
			anim.toRotation = eRotation;
			anim.angle = angle.bearing();
			anim.speed = speed;
			anim.fromColor = new Color (sR, sG, sB);
			anim.toColor = new Color (eR, eG, eB);
			anim.life = life;
			anim.fromLife = life;

			spawnCounter = 0f;
		}
	}
}
