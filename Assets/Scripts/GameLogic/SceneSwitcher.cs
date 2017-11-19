using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
	JoinMenu,
	PongGame
}

public static class SceneSwitcher
{
	public static void show(SceneType scene)
	{
		switch (scene) {
		case SceneType.JoinMenu:
			SceneManager.LoadScene ("JoinMenu");
			break;

		case SceneType.PongGame:
			SceneManager.LoadScene ("PongGame");
			break;
		}
	}
}
