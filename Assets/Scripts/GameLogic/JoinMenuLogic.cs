using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JoinMenuLogic : MonoBehaviour 
{
	private List<GameObject> uiLeave = new List<GameObject>();
	private List<GameObject> uiJoin = new List<GameObject>();
	private List<GameObject> uiChangeColor = new List<GameObject>();
	private List<GameObject> uiGamepad = new List<GameObject>();
	private List<GameObject> uiColor = new List<GameObject>();
	private List<JoystickController> controllers = new List<JoystickController> ();
	private List<int> states = new List<int>();
	private Color[] colors = {
		new Color(255f / 255f, 	0f / 255f, 		0f / 255f), 	// Red
		new Color(255f / 255f, 	0f / 255f,		255f / 255f),	// Purple
		new Color(102f / 255f, 	0f / 255f, 		255f / 255f),	// Blue
		new Color(0f / 255f, 	204f / 255f, 	255f / 255f),	// Teal
		new Color(0f / 255f, 	255f / 255f, 	0f / 255f),		// Green
		new Color(255f / 255f, 	255f / 255f, 	0f / 255f),		// Yellow
		new Color(255f / 255f, 	153f / 255f, 	0f / 255f)		// Orange
	};

	private List<int> pickerColor = new List<int> ();

	void Start () 
	{
		for (int i = 1; i <= 4; i++) {
			this.uiLeave.Add (GameObject.Find ("Canvas/Player" + i + "/ToLeave"));
			this.uiJoin.Add (GameObject.Find ("Canvas/Player" + i + "/ToJoin"));
			this.uiChangeColor.Add (GameObject.Find ("Canvas/Player" + i + "/ToChangeColor"));
			this.uiGamepad.Add (GameObject.Find ("Canvas/Player" + i + "/Controller"));
			this.uiColor.Add (GameObject.Find ("Canvas/Player" + i + "/Color"));
			this.controllers.Add(Joystick.GetJoystick("" + i));
			this.pickerColor.Add (i);
			this.states.Add (0);
			this.updateColor (i - 1);
			this.setState (i - 1, 0);
		}
	}
	
	void Update () 
	{
		for (int i = 0; i < 4; i++) {
			if (this.controllers [i].getButtonDown (JoystickButton.A)) {
				if (this.states [i] == 0) {
					this.states [i] = 1;
					this.setState (i, 1);
				} else {
					this.states [i] = 0;
					this.setState (i, 0);
				}
			} else if (this.controllers [i].getButtonDown (JoystickButton.START)) {
				if (this.states [i] == 1) {
					this.states [i] = 2;
					this.setState (i, 2);

					if (this.states [0] != 1 &&
					   this.states [1] != 1 &&
					   this.states [2] != 1 &&
					   this.states [3] != 1) {
						this.startGame ();
					}

				} else if (this.states [i] == 2) {
					this.states [i] = 1;
					this.setState (i, 1);
				}
			} else if (this.controllers [i].getButtonDown (JoystickButton.B)) {
				if (this.states [i] >= 1) {
					int x = this.pickerColor [i] + 1;
					while (true) {
						if (x < this.colors.Length) {
							if (x != this.pickerColor [0] &&
							   x != this.pickerColor [1] &&
							   x != this.pickerColor [2] &&
							   x != this.pickerColor [3]) {
								this.pickerColor [i] = x;
								break;
							}
							x++;
						} else {
							x = 0;
						}
					}
					updateColor (i);
				}
			}
		}
	}

	private void setState(int playerIndex, int state)
	{
		bool active = state >= 1;
		bool ready = state >= 2;
		this.uiLeave[playerIndex].SetActive (active);
		this.uiJoin[playerIndex].SetActive (!active);
		this.uiChangeColor[playerIndex].SetActive (active);
		this.uiGamepad[playerIndex].SetActive (active && ready);
		this.uiColor[playerIndex].SetActive (active);
	}

	private void updateColor(int playerIndex)
	{
		var image = this.uiColor [playerIndex].GetComponent<Image> ();
		image.color =this.colors[this.pickerColor [playerIndex]];
	}

	private void startGame()
	{
		setupPlayers ();
		showScene ();
	}

	private void showScene()
	{
		SceneManager.LoadScene ("PontScene");
	}

	private void setupPlayers()
	{
		Players.active.Clear (); 
		for (int i = 0; i < 4; i++) {
			if (this.states [i] == 2) {
				Players.active.Add (new Player (this.colors [this.pickerColor [i]], this.controllers [i]));
			}
		}
	}
}
