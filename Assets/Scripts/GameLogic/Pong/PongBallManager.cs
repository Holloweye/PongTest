using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PongBallManager : MonoBehaviour 
{
	private List<PlayerBall> balls = new List<PlayerBall>();

	public delegate void OnCollision(PlayerBall playerBall);
	public OnCollision onCollision;

	public delegate void OnLeave(PlayerBall playerBall);
	public OnLeave onLeave;

	public class PlayerBall
	{
		public GameObject ball;
		public PongPlayer player;

		public PlayerBall(PongPlayer player, GameObject ball)
		{
			this.ball = ball;
			this.player = player;
		}
	}

	/*
	 * Tries to get a random player free from a incoming ball.
	 * Otherwise picks a random player.
	 */
	public PongPlayer GetRandomPlayerFreeFromBallInList(List<PongPlayer> players)
	{
		var c = players.Count;
		if(c == 0)
		{
			return null;
		}
		else if(c == 1)
		{
			return players[0];
		}

		var s = (int)Mathf.Floor(Random.Range(0, c));
		for(int i = 0; i < c; i++)
		{
			var p = players[(s + i) % c];
			if(this.balls.FindLast(pb => pb.player == p) == null)
			{
				return p;
			}
		}
		return players[s];
	}

	public int GetNumberOfActiveBalls()
	{
		return this.balls.Count;
	}

	/*
	 * Spawns a new ball for a certain player.
	 */
	public void SpawnBall(PongPlayer player)
	{
		if(player == null) return;

		var ball = (GameObject)Instantiate(Resources.Load ("pong/ball"));
		ball.GetComponent<PongBall> ().onCollision = () => {
			this.onCollision(this.balls.Where(pb => pb.ball == ball).First());
		};
		ball.GetComponent<PongBall>().onLeaveGameArea = () => {
			this.SetCollision(ball, null);
		};
		ball.GetComponent<PongBall> ().onExit = () => {
			var playerBall = this.balls.Where(pb => pb.ball == ball).First();
			this.ReTarget(playerBall.ball, null);
			this.onLeave(playerBall);
		};
		this.ReTarget(ball, player);
	}

	/*
	 * Set ball to collide with a player.
	 * Also sets color of ball to match player.
	 *
	 * If null player is null then ball is removed.
	 */
	public void ReTarget(GameObject ball, PongPlayer pp)
	{
		if(ball != null)
		{
			this.balls = this.balls.Where(pb => pb.ball != ball).ToList();
			if(pp != null)
			{
				ball.GetComponent<PongBall>().color = pp.color;
				this.SetCollision(ball, pp.paddle);
				this.balls.Add(new PlayerBall(pp, ball));
			}
			else
			{
				ball.GetComponent<PongBall>().Kill();
			}
		}
	}

	/* 
	 * Makes game objects only collidable with each other.
	 * 
	 * If obj2 is set to null, obj1 will not collide with anything.
	 */
	private void SetCollision(GameObject obj1, GameObject obj2)
	{
		if(obj1 != null)
		{
			GameObject[] objects = (GameObject[])FindObjectsOfType(typeof(GameObject));
			for(int i = 0; i < objects.Length; i++)
			{
				if(objects[i] != obj1)
				{
					obj1.setCollision(objects[i], false);
				}
			}

			if(obj2 != null)
			{
				obj1.setCollision(obj2, true);
			}
		}
	}
}
