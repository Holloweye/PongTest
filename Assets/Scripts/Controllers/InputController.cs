using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType
{
	Key,
	Directional
}

public interface InputController 
{
	InputType getType();

	bool left();
	bool right();
	bool boost();

	Vector2 direction();
}
