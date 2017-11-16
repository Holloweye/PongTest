using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public string spawn;
	public float spawnRate;
	private float counter = 0f;
	private GameObject toSpawn;
	private SpriteRenderer rendering;

	void Start()
	{
		this.toSpawn = (GameObject)Resources.Load (this.spawn);
		this.rendering = GetComponent<SpriteRenderer> ();
	}

	void Update () 
	{
		this.counter += Time.deltaTime;
		if (this.counter >= this.spawnRate)
		{
			this.counter = 0f;
			var obj = Instantiate (this.toSpawn);
			obj.transform.position = this.transform.position;
			obj.transform.rotation = this.transform.rotation;

			var objRendering = obj.GetComponent<SpriteRenderer> ();
			objRendering.color = this.rendering.color;
		}
	}
}
