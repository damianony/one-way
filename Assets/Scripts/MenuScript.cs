﻿using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{
	private GUISkin skin;

	void Start() {
		skin = Resources.Load ("GUISkin") as GUISkin;
	}

	void OnGUI()
	{
		const int buttonWidth = 200;
		const int buttonHeight = 60;

		//GUI.skin = skin;
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect buttonRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);
		
		// Draw a button to start the game
		if(GUI.Button(buttonRect,"<color=white><size=20>Start!</size></color>"))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel("Stage");
		}
	}
}
