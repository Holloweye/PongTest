using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Joystick
{
	public static JoystickController GetJoystick(string joystickNumber)
	{
		Dictionary<JoystickButton, string> winButtons 	= new Dictionary<JoystickButton, string> ();
		Dictionary<JoystickAxis, string> winAxis 		= new Dictionary<JoystickAxis, string> ();
		Dictionary<JoystickButton, string> macButtons 	= new Dictionary<JoystickButton, string> ();
		Dictionary<JoystickAxis, string> macAxis 		= new Dictionary<JoystickAxis, string> ();

		winButtons [JoystickButton.A] 				= "joystick win " + joystickNumber + " a";
		winButtons [JoystickButton.B] 				= "joystick win " + joystickNumber + " b";
		winButtons [JoystickButton.X] 				= "joystick win " + joystickNumber + " x";
		winButtons [JoystickButton.Y] 				= "joystick win " + joystickNumber + " y";
		winButtons [JoystickButton.LEFT_BUMP] 		= "joystick win " + joystickNumber + " left bump";
		winButtons [JoystickButton.RIGHT_BUMP] 		= "joystick win " + joystickNumber + " right bump";
		winButtons [JoystickButton.VIEW] 			= "joystick win " + joystickNumber + " view";
		winButtons [JoystickButton.START] 			= "joystick win " + joystickNumber + " start";
		winButtons [JoystickButton.LEFT_STICK] 		= "joystick win " + joystickNumber + " left stick";
		winButtons [JoystickButton.RIGHT_STICK] 	= "joystick win " + joystickNumber + " right stick";

		winAxis [JoystickAxis.LEFT_STICK_X] 	= "joystick win " + joystickNumber + " left stick horizontal";
		winAxis [JoystickAxis.LEFT_STICK_Y] 	= "joystick win " + joystickNumber + " left stick vertical";
		winAxis [JoystickAxis.RIGHT_STICK_X] 	= "joystick win " + joystickNumber + " right stick horizontal";
		winAxis [JoystickAxis.RIGHT_STICK_Y] 	= "joystick win " + joystickNumber + " right stick vertical";
		winAxis [JoystickAxis.DPAD_X] 			= "joystick win " + joystickNumber + " dpad horizontal";
		winAxis [JoystickAxis.DPAD_Y] 			= "joystick win " + joystickNumber + " dpad vertical";
		winAxis [JoystickAxis.LEFT_TRIGGER] 	= "joystick win " + joystickNumber + " left trigger";
		winAxis [JoystickAxis.RIGHT_TRIGGER] 	= "joystick win " + joystickNumber + " right trigger";

		macButtons [JoystickButton.A] 				= "joystick mac " + joystickNumber + " a";
		macButtons [JoystickButton.B] 				= "joystick mac " + joystickNumber + " b";
		macButtons [JoystickButton.X] 				= "joystick mac " + joystickNumber + " x";
		macButtons [JoystickButton.Y] 				= "joystick mac " + joystickNumber + " y";
		macButtons [JoystickButton.LEFT_BUMP] 		= "joystick mac " + joystickNumber + " left bump";
		macButtons [JoystickButton.RIGHT_BUMP] 		= "joystick mac " + joystickNumber + " right bump";
		macButtons [JoystickButton.VIEW] 			= "joystick mac " + joystickNumber + " view";
		macButtons [JoystickButton.START] 			= "joystick mac " + joystickNumber + " start";
		macButtons [JoystickButton.LEFT_STICK] 		= "joystick mac " + joystickNumber + " left stick";
		macButtons [JoystickButton.RIGHT_STICK] 	= "joystick mac " + joystickNumber + " right stick";
		macButtons [JoystickButton.DPAD_UP] 		= "joystick mac " + joystickNumber + " dpad up";
		macButtons [JoystickButton.DPAD_LEFT] 		= "joystick mac " + joystickNumber + " dpad left";
		macButtons [JoystickButton.DPAD_DOWN] 		= "joystick mac " + joystickNumber + " dpad down";
		macButtons [JoystickButton.DPAD_RIGHT] 		= "joystick mac " + joystickNumber + " dpad right";

		macAxis [JoystickAxis.LEFT_STICK_X] 	= "joystick mac " + joystickNumber + " left stick horizontal";
		macAxis [JoystickAxis.LEFT_STICK_Y] 	= "joystick mac " + joystickNumber + " left stick vertical";
		macAxis [JoystickAxis.RIGHT_STICK_X] 	= "joystick mac " + joystickNumber + " right stick horizontal";
		macAxis [JoystickAxis.RIGHT_STICK_Y] 	= "joystick mac " + joystickNumber + " right stick vertical";
		macAxis [JoystickAxis.DPAD_X] 			= "joystick mac " + joystickNumber + " dpad horizontal";
		macAxis [JoystickAxis.DPAD_Y] 			= "joystick mac " + joystickNumber + " dpad vertical";

		return new JoystickController (winButtons, winAxis, macButtons, macAxis);
	}
}
