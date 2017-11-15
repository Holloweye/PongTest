using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializePlayers : MonoBehaviour 
{
	private Player currentPlayer;
	private GameObject currentPaddle;

	private int score1;
	private int score2;
	
	private Player player1;
	private Player player2;

	private GameObject ball;
	private GameObject paddle1;
	private GameObject paddle2;

	public Text text1;
	public Text text2;

	void Start ()
	{
		paddle1 = (GameObject)Instantiate(Resources.Load ("paddle"));
		player1 = new Player (Color.red, Joystick.GetJoystick("1"));
		paddle1.getPaddle ().player = player1;

		paddle2 = (GameObject)Instantiate(Resources.Load ("paddle"));
		player2 = new Player (Color.blue, Joystick.GetJoystick("1"));
		paddle2.getPaddle ().player = player2;

		resetBall ();
	}

	private void resetBall()
	{
		if (ball != null) {
			ball.GetComponent<Ball> ().Kill ();
			ball = null;
		}

		ball = (GameObject)Instantiate(Resources.Load ("ball"));
		ball.GetComponent<Ball> ().onCollision = () => {
			toggleCurrentPlayer ();
		};
		ball.GetComponent<Ball> ().onExit = () => {
			if(currentPlayer == player1) score2++;
			if(currentPlayer == player2) score1++;

			text1.text = "Score: " + score1;
			text2.text = "Score: " + score2;
			resetBall();
		};
		toggleCurrentPlayer ();
	}

	private void toggleCurrentPlayer()
	{
		currentPlayer = (currentPlayer != player1 ? player1 : player2);
		currentPaddle = (currentPlayer == player1 ? paddle1 : paddle2);
		setCollisionTo (ball, currentPaddle);
		ball.GetComponent<Ball>().color = currentPlayer.color;
	}

	private void setCollisionTo(GameObject ball, GameObject paddle)
	{
		var collider1 = ball.GetComponent<Collider2D> ();
		var collider2 = paddle.GetComponent<Collider2D> ();
		var collider3 = paddle1.GetComponent<Collider2D> ();
		var collider4 = paddle2.GetComponent<Collider2D> ();

		Physics2D.IgnoreCollision (collider1, collider3, true);
		Physics2D.IgnoreCollision (collider1, collider4, true);
		Physics2D.IgnoreCollision (collider1, collider2, false);
	}
}
