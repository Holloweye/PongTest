using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class PongLightningController : MonoBehaviour 
{
	private LightningBoltScript lightningBoltScript;
	private GameObject start;
	private GameObject end;

	private float time = 0f;

	private void Start () 
	{
		this.start = GameObject.Find ("SimpleLightningBoltPrefab/LightningStart");
		this.end = GameObject.Find ("SimpleLightningBoltPrefab/LightningEnd");
		this.lightningBoltScript = GameObject.Find ("SimpleLightningBoltPrefab").GetComponent<LightningBoltScript>();
		this.lightningBoltScript.ManualMode = true;
	}
	
	private void Update () 
	{
		this.time += Time.deltaTime;

		var sa = Perlin.Noise(this.time / 10f) * 360f;
		var ea = sa + 180f;

		this.lightningBoltScript.ChaosFactor = Perlin.Noise(this.time / 10f) / 10f + 0.2f;
		this.start.transform.position = sa.radians().bearing().multiply(10f).vec3();
		this.end.transform.position = ea.radians().bearing().multiply(10f).vec3();
	}

	public void active(bool active)
	{
		if(this.lightningBoltScript.ManualMode && active)
		{
			// TODO: Play sound effect.
			this.lightningBoltScript.ManualMode = false;
		}
		else if(!active)
		{
			this.lightningBoltScript.ManualMode = true;
		}
	}
}
