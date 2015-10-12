using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
	void OnGUI()
	{
		const int buttonWidth = 200;
		const int buttonHeight = 60;
		
		if (
			GUI.Button(
			// Center in X, 1/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(1 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"<color=white><size=20>Retry!</size></color>"
			)
			)
		{
			// Reload the level
			EnemyWaves.enemiesAlive = 0;
			PlayerScript.playerHealth = 5;
			PlayerScript.power = 0;
			EnemyWaves.currentDay = 0;
			//EnemyWaves.enemisLeft;
			Application.LoadLevel("Stage");
		}
		
		if (
			GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(1 * Screen.height / 3) - (buttonHeight * 2),
			buttonWidth,
			buttonHeight
			),
			"<color=white><size=20>Back to menu</size></color>"
			)
			)
		{
			// Reload the level
			EnemyWaves.enemiesAlive = 0;
			PlayerScript.playerHealth = 5;
			PlayerScript.power = 0;
			EnemyWaves.currentDay = 0;
			Application.LoadLevel("Menu");
		}
	}
}
