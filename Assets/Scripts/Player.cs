using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
	public Color color;
	public JoystickController controller;

	public Player(Color color, JoystickController controller)
	{
		this.color = color;
		this.controller = controller;
	}
}
