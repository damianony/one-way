using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

	public Text playerHealthTxt;
	public Text dayTxt;
	public Text countDownTimer;
	public Text powerMeter;
	public Image sheildbar1;
	public Image sheildbar2;
	public Image sheildbar3;
	public Image sheildbar4;
	public Image sheildbar5;
	public int regenerating = 0;
	void start() {
		PlayerScript.playerHealth = 5;
	}

	// Update is called once per frame
	void Update () {
		playerHealthTxt.text = "x " + PlayerScript.playerHealth;


		if (PlayerScript.playerHealth <= 0) {
			sheildbar1.enabled = false;
			sheildbar2.enabled = false;
			sheildbar3.enabled = false;
			sheildbar4.enabled = false;
			sheildbar5.enabled = false;
		}

		if (!(PlayerScript.playerHealth <= 0)) {
			if (PlayerScript.playerHealth == 1) {
				sheildbar1.enabled = true;
				sheildbar2.enabled = false;
				sheildbar3.enabled = false;
				sheildbar4.enabled = false;
				sheildbar5.enabled = false;
			} else if (PlayerScript.playerHealth == 2) {
				sheildbar1.enabled = true;
				sheildbar2.enabled = true;
				sheildbar3.enabled = false;
				sheildbar4.enabled = false;
				sheildbar5.enabled = false;
			} else if (PlayerScript.playerHealth == 3) {
				sheildbar1.enabled = true;
				sheildbar2.enabled = true;
				sheildbar3.enabled = true;
				sheildbar4.enabled = false;
				sheildbar5.enabled = false;
			} else if (PlayerScript.playerHealth == 4) {
				sheildbar1.enabled = true;
				sheildbar2.enabled = true;
				sheildbar3.enabled = true;
				sheildbar4.enabled = true;
				sheildbar5.enabled = false;
			} else if (PlayerScript.playerHealth == 5) {
				sheildbar1.enabled = true;
				sheildbar2.enabled = true;
				sheildbar3.enabled = true;
				sheildbar4.enabled = true;
				sheildbar5.enabled = true;
			}
		}
		if (PlayerScript.playerHealth < 5 && !(PlayerScript.playerHealth <= 0) && regenerating == 0) {
			StartCoroutine (regen ());
		}
		dayTxt.text = "Day " + EnemyWaves.currentDay;
		string s = string.Format("{0:000000}", PlayerScript.power);
		powerMeter.text = s;
	}

	public IEnumerator regen() {
		regenerating = 1;
		yield return new WaitForSeconds(10.0f);
		if (PlayerScript.playerHealth < 5 && !(PlayerScript.playerHealth <= 0)) {
			PlayerScript.playerHealth++;
		}
		regenerating = 0;
	}
}
