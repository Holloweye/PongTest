using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
	public Color color;
	public InputController controller;

	public Player(Color color, InputController controller)
	{
		this.color = color;
		this.controller = controller;
	}
}
