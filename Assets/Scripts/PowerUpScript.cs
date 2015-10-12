using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpScript : MonoBehaviour {

	public Text powerUpTxt;
	public Text buttonTxt;
	public GameObject player;
	private WeaponScript playerWeapon;

	// Use this for initialization
	void Start () {
		//playerWeapon = player.gameObject.GetComponent<WeaponScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (PlayerScript.power < 30) {
			buttonTxt.text = "";
		} else {
			buttonTxt.text = "Press Space";
		}

		if (PlayerScript.power < 30) {
			powerUpTxt.text = "";
		} else if (PlayerScript.power >= 30 && PlayerScript.power < 60) {
			powerUpTxt.text = "Rapid Fire";
		} else if (PlayerScript.power >= 60 && PlayerScript.power < 100) {
			powerUpTxt.text = "Laser Beam";
		} else if (PlayerScript.power == 100) {
			powerUpTxt.text = "Mega Blaster";
		}*/

		/*if(Input.GetKeyDown(KeyCode.Space) && PlayerScript.power >= 30) {
			usePowerUp ();
		}*/
	}

	/*void usePowerUp() {
		if (PlayerScript.power >= 30 && PlayerScript.power < 60) {
			StartCoroutine(playerWeapon.rapidFire ());
		} else if (PlayerScript.power >= 60 && PlayerScript.power < 100) {
			StartCoroutine(playerWeapon.laserBeam ());
		} else if (PlayerScript.power == 100) {
			StartCoroutine(playerWeapon.megaBlaster ());
		}

		powerUpTxt.text = "";
		buttonTxt.text = "";
		PlayerScript.power = 0;
	}*/
}
