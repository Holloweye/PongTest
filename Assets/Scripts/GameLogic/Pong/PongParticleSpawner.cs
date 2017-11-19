using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongParticleSpawner : MonoBehaviour 
{
	public float spawnRate = 0.1f;
	public float lifeConst = 3f;
	public float lifeMulti = 0f;
	public float startScaleConst = 3f;
	public float startScaleMulti = 2f;
	public float endScaleConst = 0f;
	public float endScaleMulti = 2f;
	public float startRotationConst = 0f;
	public float startRotationMulti = 360f;
	public float endRotationConst = 0f;
	public float endRotationMulti = 360f;
	public float angleConst = 0f;
	public float angleMulti = 360f;
	public float speedConst = 0f;
	public float speedMulti = 3f;
	public float startRedConst = 0.5f;
	public float startRedMulti = 0.5f;
	public float startGreenConst = 0.5f;
	public float startGreenMulti = 0.5f;
	public float startBlueConst = 0.5f;
	public float startBlueMulti = 0.5f;
	public float startAlphaConst = 1f;
	public float startAlphaMulti = 0f;
	public float endRedConst = 0.5f;
	public float endRedMulti = 0.5f;
	public float endGreenConst = 0.5f;
	public float endGreenMulti = 0.5f;
	public float endBlueConst = 0.5f;
	public float endBlueMulti = 0.5f;
	public float endAlphaConst = 0f;
	public float endAlphaMulti = 0f;
	public float xConst = -1f;
	public float xMulti = 2f;
	public float yConst = -1f;
	public float yMulti = 2f;

	private float spawnCounter = 0f;
	private float time = 0f;

	void Update () 
	{
		spawnCounter += Time.deltaTime;
		time += Time.deltaTime;
		if (spawnCounter >= spawnRate) {

			var square = (GameObject)Instantiate(Resources.Load ("pong/square"));
			square.transform.position = new Vector3 (
				this.alg(this.time, 17f) * this.xMulti + this.xConst, 
				this.alg(this.time, 18f) * this.yMulti + this.yConst, 
				0f);

			var particle = square.GetComponent<ParticleEffect> ();
			particle.life 			= this.alg(this.time, 1f) * this.lifeMulti 			+ this.lifeConst;
			particle.fromRotation 	= this.alg(this.time, 2f) * this.startRotationMulti + this.startRotationConst;
			particle.toRotation 	= this.alg(this.time, 3f) * this.endRotationMulti 	+ this.endRotationConst;
			particle.fromScale 		= this.alg(this.time, 4f) * this.startScaleMulti 	+ this.startScaleConst;
			particle.toScale 		= this.alg(this.time, 5f) * this.endScaleMulti 		+ this.endScaleConst;
			particle.speed 			= this.alg(this.time, 7f) * this.speedMulti 		+ this.speedConst;

			particle.fromColor 		= new Color (
				this.alg(this.time, 8f) * this.startRedMulti 	+ this.startRedConst, 
				this.alg(this.time, 9f) * this.startGreenMulti 	+ this.startGreenConst, 
				this.alg(this.time, 10f) * this.startBlueMulti 	+ this.startBlueConst, 
				this.alg(this.time, 11f) * this.startAlphaMulti + this.startAlphaConst
			);
			
			particle.toColor 		= new Color (
				this.alg(this.time, 12f) * this.endRedMulti 	+ this.endRedConst, 
				this.alg(this.time, 13f) * this.endGreenMulti 	+ this.endGreenConst, 
				this.alg(this.time, 14f) * this.endBlueMulti 	+ this.endBlueConst, 
				this.alg(this.time, 15f) * this.endAlphaMulti 	+ this.endAlphaConst
			);

			particle.angle = (this.alg(this.time, 16f) * this.angleMulti + this.angleConst).radians().bearing();
			particle.fromLife = particle.life;

			particle.updateColor ();
			particle.updatePosition ();

			spawnCounter = 0f;
		}
	}

	private float alg(float x, float y)
	{
		return Perlin.Noise ((x + y * 100f) / 10f);
	}
}
