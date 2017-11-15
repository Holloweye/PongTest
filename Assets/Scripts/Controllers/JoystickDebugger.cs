using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickDebugger : MonoBehaviour
{
	private JoystickController controller;
	public string joystick;

	void Start()
	{
		this.controller = Joystick.GetJoystick (this.joystick);
	}

	void Update()
	{
		foreach(JoystickButton e in Enum.GetValues(typeof(JoystickButton)))
		{
			if (this.controller.getButton (e)) 
			{
				Debug.Log ("" + e.ToString () + " - isPressed");
			}
		}

		foreach(JoystickAxis e in Enum.GetValues(typeof(JoystickAxis)))
		{
			if (this.controller.getAxis(e) != 0f) 
			{
				Debug.Log ("" + e.ToString () + " - " + this.controller.getAxis(e));
			}
		}
	}
}
