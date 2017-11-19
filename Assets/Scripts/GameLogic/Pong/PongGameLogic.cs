using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongGameLogic : MonoBehaviour 
{
	private GameObject ball;

	private List<PongPlayer> players = new List<PongPlayer>();
	private int currentPlayerIndex;

	void Start ()
	{
		foreach (Player player in Players.active) {
			this.players.Add (new PongPlayer (player, (GameObject)Instantiate (Resources.Load ("pong/paddle")), 3));
		}
		this.currentPlayerIndex = 0;

		this.killBall ();
		this.spawnBall ();
		this.toggleCurrentPlayer ();
	}

	private void killBall()
	{
		if (this.ball != null) {
			this.ball.GetComponent<PongBall> ().Kill ();
			this.ball = null;
		}
	}

	private void spawnBall()
	{
		this.ball = (GameObject)Instantiate(Resources.Load ("pong/ball"));
		this.ball.GetComponent<PongBall> ().onCollision = () => {
			this.toggleCurrentPlayer ();
		};
		this.ball.GetComponent<PongBall>().onLeaveGameArea = () => {

		};
		this.ball.GetComponent<PongBall> ().onExit = () => {

			this.currentPlayer().hearts--;
			this.removeKilledPlayers();

			if(this.isGameOver())
			{
				SceneSwitcher.show(SceneType.JoinMenu);
			}
			else
			{
				this.killBall();
				this.spawnBall();
				this.toggleCurrentPlayer ();
			}
		};
	}

	private bool isGameOver()
	{
		return this.players.Count <= 1;
	}

	private void removeKilledPlayers()
	{
		foreach (PongPlayer pp in this.players) {
			if (pp.hearts <= 0) {
				pp.paddle.GetComponent<PongPaddle> ().kill ();
			}
		}
		this.players = this.players.Where (player => player.hearts > 0).ToList ();
	}

	private void toggleCurrentPlayer()
	{
		this.currentPlayerIndex++;
		if (this.currentPlayerIndex >= this.players.Count) {
			this.currentPlayerIndex = 0;
		}
		this.updateBallCollision ();
		this.ball.GetComponent<PongBall>().color = this.currentPlayer().color;
	}

	private void updateBallCollision()
	{
		foreach (PongPlayer pp in this.players) {
			this.ball.setCollision(pp.paddle, false);
		}
		this.ball.setCollision(this.currentPlayer().paddle, true);
	}

	private PongPlayer currentPlayer()
	{
		if (this.currentPlayerIndex < this.players.Count) {
			return this.players [this.currentPlayerIndex];
		}
		return null;
	}
}
