using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputController : InputController 
{
	private KeyCode leftKey;
	private KeyCode rightKey;
	private KeyCode boostKey;

	public KeyInputController(KeyCode left, KeyCode right, KeyCode boost)
	{
		this.leftKey = left;
		this.rightKey = right;
		this.boostKey = boost;
	}

	public InputType getType()
	{
		return InputType.Key;
	}

	public bool left()
	{
		return Input.GetKey (this.leftKey);
	}

	public bool right()
	{
		return Input.GetKey (this.rightKey);
	}

	public bool boost()
	{
		return Input.GetKey (this.boostKey);
	}

	public Vector2 direction()
	{
		return new Vector2();
	}
}
