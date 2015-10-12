using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public static int playerHealth = 5;
	public static int power = 0;
	//public Animation exhaust;
	public Vector2 playerSpeed = new Vector2(20, 20);
	public Renderer rend;

	void start() {
		rend = GetComponent<Renderer>();
		power = 0;
		playerHealth = 5;
	}

	void Update () {
		//player movement
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		if (Input.touchCount > 0) {
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch (0);
			
			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
				// If the finger is on the screen, move the object smoothly to the touch position
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 10));                
				transform.position = Vector3.Lerp (transform.position, touchPosition, 0.25f);
			}
		} else {
			Vector3 movement = new Vector3 (playerSpeed.x * inputX, playerSpeed.y * inputY, 0);
			
			movement *= Time.deltaTime;
			transform.Translate (movement);
		}

		/*if (Input.touchCount > 0) {
			inputX = Input.GetTouch (0).deltaPosition.x * Time.deltaTime;
			inputY = Input.GetTouch (0).deltaPosition.y * Time.deltaTime;

			Vector3 movement = new Vector3 (inputX*2, inputY*2, 0);

			transform.Translate (movement);*/

			/*foreach (Touch touch in Input.touches) {
				if (touch.phase == TouchPhase.Began) {
					Shoot ();
					
					Vector3 touchPosition = Camera.main.ScreenToWorldPoint (touch.position);
					
					if (enemyCollider.OverlapPoint (touchPosition)) {
						TakeDamage (this.health);
					}
				}
			}
		} else {
			Vector3 movement = new Vector3 (playerSpeed.x * inputX, playerSpeed.y * inputY, 0);

			movement *= Time.deltaTime;
			transform.Translate (movement);
		}*/

		//Vector3 playerPosition = transform.position;
		//exhaust.transform.position = new Vector3(playerPosition.x, playerPosition.y - 0.25f ,playerPosition.z);

		//click shooting
		//bool shoot = Input.GetButtonDown ("Fire1");
		//shoot |= Input.GetButtonDown ("Fire2");

		WeaponScript weapons = GetComponent<WeaponScript>();
		if(weapons != null) {
			weapons.Attack(false);
			//SoundEffectsHelper.Instance.MakePlayerShotSound();
		}
		/*foreach (WeaponScript weapon in weapons)
		{
			if (weapon != null && weapon.enabled && weapon.CanAttack)
			{
				weapon.Attack(true);
				SoundEffectsHelper.Instance.MakeEnemyShotSound();
			}
		}*/
		//Camera bounds, player doesn't leave screen
		float w = rend.bounds.size.x;
		float h = rend.bounds.size.y;

		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;

		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder + w/2, rightBorder - w/2),
			Mathf.Clamp(transform.position.y, topBorder + h/2, bottomBorder - h/2),
			transform.position.z
			);

		/*if(cityHealth <= 0 ) {
			transform.parent.gameObject.AddComponent<GameOverScript> ();
		}*/
	}

	void OnDestroy() {
		transform.parent.gameObject.AddComponent<GameOverScript> ();
	}
}
