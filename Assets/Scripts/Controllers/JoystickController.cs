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
	RIGHT_STICK,
	DPAD_UP,
	DPAD_LEFT,
	DPAD_DOWN,
	DPAD_RIGHT
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
	private Dictionary<JoystickButton, string> winButtons;
	private Dictionary<JoystickAxis, string> winAxis;
	private Dictionary<JoystickButton, string> macButtons;
	private Dictionary<JoystickAxis, string> macAxis;

	private bool isMac;

	public JoystickController(
		Dictionary<JoystickButton, string> winButtons,
		Dictionary<JoystickAxis, string> winAxis,
		Dictionary<JoystickButton, string> macButtons,
		Dictionary<JoystickAxis, string> macAxis
	)
	{
		this.winButtons = winButtons;
		this.winAxis = winAxis;
		this.macButtons = macButtons;
		this.macAxis = macAxis;
		this.isMac = 
			Application.platform == RuntimePlatform.OSXEditor || 
			Application.platform == RuntimePlatform.OSXPlayer;
	}

	public bool getButton(JoystickButton button)
	{
		if (button == JoystickButton.DPAD_UP && !this.isMac) 
		{
			return Input.GetAxis (this.getAxisName (JoystickAxis.DPAD_Y)) <= -0.5f;
		}
		else if (button == JoystickButton.DPAD_DOWN && !this.isMac) 
		{
			return Input.GetAxis (this.getAxisName (JoystickAxis.DPAD_Y)) >= 0.5f;
		}
		else if (button == JoystickButton.DPAD_LEFT && !this.isMac) 
		{
			return Input.GetAxis (this.getAxisName (JoystickAxis.DPAD_X)) <= -0.5f;
		}
		else if (button == JoystickButton.DPAD_RIGHT && !this.isMac) 
		{
			return Input.GetAxis (this.getAxisName (JoystickAxis.DPAD_X)) >= 0.5f;
		}
		return Input.GetButton (this.getButtonName (button));
	}

	public bool getButtonDown(JoystickButton button)
	{
		return Input.GetButtonDown (this.getButtonName (button));
	}

	public bool getButtonUp(JoystickButton button)
	{
		return Input.GetButtonUp (this.getButtonName (button));
	}

	public float getAxis(JoystickAxis axis)
	{
		if (axis == JoystickAxis.DPAD_X && this.isMac) 
		{
			if (getButton (JoystickButton.DPAD_LEFT)) {
				return -1.0f;
			} else if (getButton (JoystickButton.DPAD_RIGHT)) {
				return 1.0f;
			}
		}
		else if (axis == JoystickAxis.DPAD_Y && this.isMac) 
		{
			if (getButton (JoystickButton.DPAD_UP)) {
				return -1.0f;
			} else if (getButton (JoystickButton.DPAD_DOWN)) {
				return 1.0f;
			}
		}
		return Input.GetAxis (this.getAxisName (axis));
	}

	public bool isStickOverThreshold(JoystickAxis axis1, JoystickAxis axis2, float threshold = 0.1f)
	{
		return isAxisOverThreshold (axis1, threshold) || isAxisOverThreshold (axis2, threshold);
	}

	public bool isAxisOverThreshold(JoystickAxis axis, float threshold = 0.1f)
	{
		float value = getAxis (axis);
		float upper = Mathf.Abs (threshold);
		float lower = 0f - upper;
		return value <= lower || value >= upper;
	}

	private string getButtonName(JoystickButton button)
	{
		if (this.isMac) {
			if (this.macButtons.ContainsKey (button)) {
				return this.macButtons [button];
			}
		} else {
			if (this.winButtons.ContainsKey (button)) {
				return this.winButtons [button];
			}
		}
		return "";
	}

	private string getAxisName(JoystickAxis axis)
	{
		if (this.isMac) {
			if (this.macAxis.ContainsKey (axis)) {
				return this.macAxis [axis];
			}
		} else {
			if (this.winAxis.ContainsKey (axis)) {
				return this.winAxis [axis];
			}
		}
		return "";
	}
}
