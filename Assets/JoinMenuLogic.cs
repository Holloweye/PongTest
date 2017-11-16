using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinMenuLogic : MonoBehaviour 
{
	private List<GameObject> uiLeave = new List<GameObject>();
	private List<GameObject> uiJoin = new List<GameObject>();
	private List<GameObject> uiChangeColor = new List<GameObject>();
	private List<GameObject> uiGamepad = new List<GameObject>();
	private List<GameObject> uiColor = new List<GameObject>();
	private List<JoystickController> controllers = new List<JoystickController> ();
	private List<int> states = new List<int>();

	void Start () 
	{
		for (int i = 1; i <= 4; i++) {
			this.uiLeave.Add (GameObject.Find ("Canvas/Player" + i + "/ToLeave"));
			this.uiJoin.Add (GameObject.Find ("Canvas/Player" + i + "/ToJoin"));
			this.uiChangeColor.Add (GameObject.Find ("Canvas/Player" + i + "/ToChangeColor"));
			this.uiGamepad.Add (GameObject.Find ("Canvas/Player" + i + "/Controller"));
			this.uiColor.Add (GameObject.Find ("Canvas/Player" + i + "/Color"));
			this.controllers.Add(Joystick.GetJoystick("" + i));
			this.states.Add (0);
			setState (i - 1, 0);
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
				} else if (this.states [i] == 2) {
					this.states [i] = 1;
					this.setState (i, 1);
				}
			} else if (this.controllers [i].getButtonDown (JoystickButton.B)) {
				// TODO: CHANGE COLOR.
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
}
