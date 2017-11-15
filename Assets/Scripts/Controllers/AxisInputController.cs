using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisInputController : InputController 
{
	public InputType getType()
	{
		return InputType.Directional;
	}

	public bool left()
	{
		return false;
	}

	public bool right()
	{
		return false;
	}

	public bool boost()
	{
		return false;
	}

	public Vector2 direction()
	{
		return new Vector2(Input.GetAxis ("Left Stick X Axis"), Input.GetAxis("Left Stick Y Axis"));
	}
}
