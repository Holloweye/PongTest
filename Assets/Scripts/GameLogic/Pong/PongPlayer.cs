using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayer : Player 
{
	public int hearts;
	public GameObject paddle;

	public PongPlayer(Player player, GameObject paddle, int hearts) : base(player.color, player.controller)
	{
		this.paddle = paddle;
		this.hearts = hearts;
	}
}
