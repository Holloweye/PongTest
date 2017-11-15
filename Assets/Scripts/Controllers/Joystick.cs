using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Joystick
{
	public static JoystickController GetJoystick(string joystickNumber)
	{
		Dictionary<JoystickButton, string> buttons 	= new Dictionary<JoystickButton, string> ();
		Dictionary<JoystickAxis, string> axis 		= new Dictionary<JoystickAxis, string> ();

		buttons [JoystickButton.A] 				= "joystick " + joystickNumber + " a";
		buttons [JoystickButton.B] 				= "joystick " + joystickNumber + " b";
		buttons [JoystickButton.X] 				= "joystick " + joystickNumber + " x";
		buttons [JoystickButton.Y] 				= "joystick " + joystickNumber + " y";
		buttons [JoystickButton.LEFT_BUMP] 		= "joystick " + joystickNumber + " left bump";
		buttons [JoystickButton.RIGHT_BUMP] 	= "joystick " + joystickNumber + " right bump";
		buttons [JoystickButton.VIEW] 			= "joystick " + joystickNumber + " view";
		buttons [JoystickButton.START] 			= "joystick " + joystickNumber + " start";
		buttons [JoystickButton.LEFT_STICK] 	= "joystick " + joystickNumber + " left stick";
		buttons [JoystickButton.RIGHT_STICK] 	= "joystick " + joystickNumber + " right stick";

		axis [JoystickAxis.LEFT_STICK_X] 	= "joystick " + joystickNumber + " left stick horizontal";
		axis [JoystickAxis.LEFT_STICK_Y] 	= "joystick " + joystickNumber + " left stick vertical";
		axis [JoystickAxis.RIGHT_STICK_X] 	= "joystick " + joystickNumber + " right stick horizontal";
		axis [JoystickAxis.RIGHT_STICK_Y] 	= "joystick " + joystickNumber + " right stick vertical";
		axis [JoystickAxis.DPAD_X] 			= "joystick " + joystickNumber + " dpad horizontal";
		axis [JoystickAxis.DPAD_Y] 			= "joystick " + joystickNumber + " dpad vertical";
		axis [JoystickAxis.LEFT_TRIGGER] 	= "joystick " + joystickNumber + " left trigger";
		axis [JoystickAxis.RIGHT_TRIGGER] 	= "joystick " + joystickNumber + " right trigger";

		return new JoystickController (buttons, axis);
	}
}
