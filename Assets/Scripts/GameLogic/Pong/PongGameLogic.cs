using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongGameLogic : MonoBehaviour 
{
	private PongPlayers players;
	private PongBallManager ballManager;

	void Start ()
	{
		List<PongPlayer> list = new List<PongPlayer>();
		foreach (Player player in Players.active) 
		{
			list.Add (new PongPlayer (player, (GameObject)Instantiate (Resources.Load ("pong/paddle")), 3));
		}
		this.players = new PongPlayers(list);

		this.ballManager = GetComponent<PongBallManager>();
		this.ballManager.SpawnBall(this.ballManager.GetRandomPlayerFreeFromBallInList(this.players.list));
		this.ballManager.onCollision = (pb) => {
			this.ballManager.ReTarget(pb.ball, this.players.NextPlayer(pb.player));
		};
		this.ballManager.onLeave = (pb) => {
			pb.player.hearts--;
			this.players.RemoveDeadPlayers();
			this.ballManager.SpawnBall(this.ballManager.GetRandomPlayerFreeFromBallInList(this.players.list));
		};
	}
}
