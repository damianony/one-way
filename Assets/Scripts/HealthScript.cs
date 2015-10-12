using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int hp = 2;
	public bool isEnemy = true;
	public GameObject explosion;
	public GameObject mineExplosion;

	//missile collision, damage
	void OnTriggerEnter2D (Collider2D collider) {
		string name = collider.gameObject.name;
		if (name == "EnemyShot(Clone)" || name == "Shot(Clone)" || name == "Bomb(Clone)") {
			ShotScript shot = collider.gameObject.GetComponent<ShotScript> ();
			if (shot != null) {
				if (shot.isEnemyShot != isEnemy) {
					hp -= shot.damage;
					Destroy (shot.gameObject);
					if (hp <= 0 && isEnemy) {
						EnemyWaves.enemiesAlive--;
						/*if (PlayerScript.power < 100) {
							PlayerScript.power++;
						}*/
						addPoints (name);
						//SpecialEffectsHelper.Instance.Explosion(transform.position);
						/*if(gameObject.name == "Mine(Clone)") {
							PlayMineExplosion ();
						} else {*/
							PlayExplosion ();
						//}
						SoundEffectsHelper.Instance.MakeExplosionSound ();
						Destroy (gameObject);
					} else if (PlayerScript.playerHealth <= 0 && !isEnemy) {
						PlayExplosion ();
						SoundEffectsHelper.Instance.MakeExplosionSound ();
						Destroy (gameObject);
						transform.parent.gameObject.AddComponent<GameOverScript> ();
					}

					if(isEnemy) {
						StartCoroutine(flash ());
					}

					if (!isEnemy) {
						if(!(PlayerScript.playerHealth <= 0)) {
							PlayerScript.playerHealth--;
						}
						StartCoroutine(playerflash());
					}
				}
			}
		} else if (name == "Enemy(Clone)" || name == "Bomber(Clone)" || name == "FighterAce(Clone)"
		           || name == "BomberAce(Clone)" || name == "Mine(Clone)" || name == "Player") {

			if(name == "Player" || this.name == "Player") {
				if (isEnemy) {
					hp -= 1;
					EnemyWaves.enemiesAlive--;
					addPoints (name);
					//SpecialEffectsHelper.Instance.Explosion(transform.position);
					/*if(gameObject.name == "Mine(Clone)") {
						PlayMineExplosion ();
					} else {*/
					PlayExplosion ();
					//}
					SoundEffectsHelper.Instance.MakeExplosionSound ();
					Destroy (gameObject);
				} else if (PlayerScript.playerHealth <= 0 && !isEnemy) {
					PlayExplosion ();
					SoundEffectsHelper.Instance.MakeExplosionSound ();
					Destroy (gameObject);
					transform.parent.gameObject.AddComponent<GameOverScript> ();
				}

				if(isEnemy) {
					StartCoroutine(flash ());
				}


				if (!isEnemy) {
					if(!(PlayerScript.playerHealth <= 0)) {
						PlayerScript.playerHealth--;
					}
					StartCoroutine(playerflash());
				}
			}
		}
	}

	public IEnumerator flash() {
		Renderer rend = gameObject.GetComponent<Renderer>();
		rend.material.color = Color.red;
		yield return new WaitForSeconds(.1f);
		rend.material.color = Color.white;
	}

	public IEnumerator playerflash() {
		Renderer rend = gameObject.GetComponent<Renderer>();
		for (int x = 0; x < 10; x++) {
			rend.material.color = Color.clear;
			yield return new WaitForSeconds (.1f);
			rend.material.color = Color.white;
			yield return new WaitForSeconds (.1f);
		}
	}

	void addPoints(string n) {
		if (name == "Enemy(Clone)") {
			PlayerScript.power += 100;
		} else if (name == "Bomber(Clone)") {
			PlayerScript.power += 250;
		} else if (name == "FighterAce(Clone)") {
			PlayerScript.power += 200;
		} else if (name == "BomberAce(Clone)") {
			PlayerScript.power += 500;
		} else if (name == "Mine(Clone)") {
			PlayerScript.power += 100;
		}
	}

	void PlayExplosion() {
		explosion = (GameObject)Instantiate (explosion);
		explosion.transform.position = transform.position;
	}

	void PlayMineExplosion() {
		explosion = (GameObject)Instantiate (mineExplosion);
		mineExplosion.transform.position = transform.position;
	}

//	void hit() {

		/*float o = 1;
		for (int x = 0; x < 4; x++) {
			o -= 0.2;
			gameObject.GetComponent<SpriteRenderer>().color.a = o;
			yield return new WaitForSeconds (.05);
		}

		yield return new WaitForSeconds (.3);

		for (int x = 0; x < 4; x++) {
			o += 0.2;
			gameObject.GetComponent<SpriteRenderer>().color.a = o;
			yield return new WaitForSeconds (.05);
		}
	}*/
}
