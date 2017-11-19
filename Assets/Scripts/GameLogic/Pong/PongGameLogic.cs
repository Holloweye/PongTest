using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongGameLogic : MonoBehaviour 
{
	private PongPlayers players;
	private PongBallManager ballManager;
	private const float timeUntilExtraBall = 5f;
	private float extraBallTimer = timeUntilExtraBall;

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

			// Reset timer for extra ball.
			// If players can't handle the balls as it is, don't add new one.
			this.extraBallTimer = timeUntilExtraBall;

			// Only spawn a new ball directly again if there is none active.
			if(this.ballManager.GetNumberOfActiveBalls() == 0)
			{
				this.ballManager.SpawnBall(this.ballManager.GetRandomPlayerFreeFromBallInList(this.players.list));
			}
		};
	}

	void Update()
	{
		// Spawn a extra ball if players are doing well.
		// But a maximum of number of balls equal to the amount of players.
		this.extraBallTimer -= Time.deltaTime;
		if(this.extraBallTimer <= 0f && this.ballManager.GetNumberOfActiveBalls() < this.players.list.Count)
		{
			this.ballManager.SpawnBall(this.ballManager.GetRandomPlayerFreeFromBallInList(this.players.list));
			this.extraBallTimer = timeUntilExtraBall;
		}
	}
}
