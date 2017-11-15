using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JoystickButton
{
	A,
	B,
	X,
	Y,
	LEFT_BUMP,
	RIGHT_BUMP,
	VIEW,
	START,
	LEFT_STICK,
	RIGHT_STICK
}

public enum JoystickAxis
{
	LEFT_STICK_X,
	LEFT_STICK_Y,
	RIGHT_STICK_X,
	RIGHT_STICK_Y,
	DPAD_X,
	DPAD_Y,
	LEFT_TRIGGER,
	RIGHT_TRIGGER
}

public class JoystickController
{
	private Dictionary<JoystickButton, string> buttons;
	private Dictionary<JoystickAxis, string> axis;

	public JoystickController(
		Dictionary<JoystickButton, string> buttons,
		Dictionary<JoystickAxis, string> axis
	)
	{
		this.buttons = buttons;
		this.axis = axis;
	}

	public bool getKey(JoystickButton button)
	{
		return Input.GetButton (this.getButtonName (button));
	}

	public bool getKeyDown(JoystickButton button)
	{
		return Input.GetButtonDown (this.getButtonName (button));
	}

	public bool getKeyUp(JoystickButton button)
	{
		return Input.GetButtonUp (this.getButtonName (button));
	}

	public float getAxis(JoystickAxis axis)
	{
		return Input.GetAxis (this.getAxisName (axis));
	}

	private string getButtonName(JoystickButton button)
	{
		if (this.buttons.ContainsKey (button)) 
		{
			return this.buttons [button];
		}
		return "";
	}

	private string getAxisName(JoystickAxis axis)
	{
		if (this.axis.ContainsKey (axis)) 
		{
			return this.axis [axis];
		}
		return "";
	}
}
