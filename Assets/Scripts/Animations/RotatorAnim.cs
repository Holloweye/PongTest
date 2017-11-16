using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorAnim : MonoBehaviour 
{
	public float rotationSpeed = 0.5f;

	void Update () 
	{
		transform.Rotate (0f, 0f, rotationSpeed);
	}
}
