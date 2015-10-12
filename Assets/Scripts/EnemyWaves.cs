using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/* float duration = 2.0f;
while (duration > 0){
     duration -= Time.deltaTime;
     // Check to see if I should end?
     yield return null;
}
*/
public class EnemyWaves : MonoBehaviour {

	public GameObject fighter;
	public GameObject bomber;
	public GameObject fighterAce;
	public GameObject bomberAce;
	public GameObject mine;
	public GameObject cam;
	public Text waveText;

	private IEnumerator waveCoroutine;
	private IEnumerator spawnCoroutine;

	private int waveNumber;
	private int wave;
	private int f;
	private int enemiesLeft;
	private bool waveInProgress;

	public static int currentDay;
	public static int enemiesAlive;

	void Start() {
		waveNumber = 0;
		wave = 0;
		enemiesLeft = 0;
		waveInProgress = false;
		currentDay = 0;
		enemiesAlive = 0;
		f = 0;
	}

	void Update () {
		if (!waveInProgress) {
			StartCoroutine (waveCaller ());
		}
	}

	public IEnumerator waveCaller() {
		waveInProgress = true;
		if (enemiesAlive == 0 && enemiesLeft == 0) {
			if(currentDay < 32) {
				currentDay++;
			}
			int delay = 4;
			wave++;
			string message = "-- Wave " + wave + " --";
			waveText.text = message;
			waveText.enabled = true;
			yield return new WaitForSeconds(delay);
			waveText.enabled = false;
			/*if((PlayerScript.cityHealth + 25) >= 50) {
				PlayerScript.cityHealth = 50;
			} else {
				PlayerScript.cityHealth = PlayerScript.cityHealth + 25;
			}*/

			StartCoroutine(spawnWave (wave));
		}
		waveInProgress = false;
	}

	public IEnumerator spawnWave(int w) {
		int phase = 0;
		float delaybetweenloopspawns = 4f;
		float delaybetweenenemyspawns = 1f;
		if (w % 4 == 0) {
			f += 2;
		}
		int groupSize = 2 + f;
		int numberOfGroups = 2 + w * 2;

		if (0 < w && w <= 4) {
			phase = 0;
		} else if (4 < w && w <= 8) {
			phase = 1;
		} else if (8 < w && w <= 12) {
			phase = 2;
		} else if (12 < w && w <= 16) {
			phase = 3;
		} else if (16 < w && w <= 20) {
			phase = 4;
		}

		if ((w % 4) == 0) {
			phase = 6;
			groupSize = w;
			numberOfGroups = w;
			delaybetweenloopspawns = 1f;
		}

		waveCoroutine = waveBuilder (phase, groupSize, numberOfGroups, 
		                             delaybetweenenemyspawns, delaybetweenloopspawns);

		/*
		if (w == 1) {
			waveCoroutine = waveBuilder (phase, 2, 4, 1f, delaybetweenspawns);
		} else if (w == 2) {
			waveCoroutine = waveBuilder (phase, 2, 6, 1f, delaybetweenspawns);
		} else if (w == 3) {
			waveCoroutine = waveBuilder (phase, 2, 10, 1f, delaybetweenspawns);
		} else if (w == 4) {
			waveCoroutine = waveBuilder (phase, 2, 10, 1f, delaybetweenspawns);
		} else if (w == 5) {
			waveCoroutine = waveBuilder (phase, 4, 12, 1f, delaybetweenspawns);
		} else if (w == 6) {
			waveCoroutine = waveBuilder (phase, 4, 16, 1f, delaybetweenspawns);
		} else if (w == 7) {
			waveCoroutine = waveBuilder (phase, 4, 20, 1f, delaybetweenspawns);
		}
		*/
		StartCoroutine(waveCoroutine);
		yield return new WaitForSeconds(5);
	}
	/*
	 * #enemy types allowed, enemies per loop, number of loops, delay between each spawn, delay between each loop 
	 */
	public IEnumerator waveBuilder(int phase, int numEnemiesPerLoop, int loops, float maxSpawnNowDelay, float maxYield) {
		enemiesLeft = numEnemiesPerLoop * loops;
		for(int x = 0; x < loops; x++) {
			spawnCoroutine = spawnNow (phase, numEnemiesPerLoop, maxSpawnNowDelay);
			StartCoroutine (spawnCoroutine);
			yield return new WaitForSeconds(Random.Range(maxYield/2, maxYield));
		}
	}

	public IEnumerator spawnNow(int phase, int loop, float wait) {
		float spawnType = Random.Range (0, 5);
		
		Vector2 minSpawnPoint = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 maxSpawnPoint = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		float xSpawnPoint = Random.Range (minSpawnPoint.x + 0.4f, maxSpawnPoint.x - 0.4f);

		float spawnAdjust = 0f;
		float type = 0;

		//fighters and bombers
		if (phase == 1) {
			type = Random.Range (0, 100);
			if(type >= 50) {
				loop = loop/2;
				enemiesLeft -= loop;
			}
		}

		//fighters, bombers and small groups fighter aces
		if (phase == 2) {
			type = Random.Range (0, 100);
			if(type <= 66) {
				loop = loop/2;
				enemiesLeft -= loop;
			}
		}

		//fighters, bombers and fighter aces, bomber aces
		if (phase == 3) {
			type = Random.Range (0, 100);
			if(type <= 50) {
				loop = loop/2;
				enemiesLeft -= loop;
			}
		}

		//fighter aces, bomber aces
		if (phase == 4) {
			type = Random.Range (0, 100);
			if(type <= 50) {
				loop = loop/2;
				enemiesLeft -= loop;
			}
		}

		for (int x = 0; x < loop; x++) {

			/*if (spawnType <= 1) {
				spawnAdjust = 0f;
			} else if (spawnType > 1 && spawnType <= 2) {
				if(xSpawnPoint + spawnAdjust + 5f >= maxSpawnPoint.x) {
					spawnAdjust = 0f;
				} else {
					spawnAdjust = spawnAdjust + 5f;
				}
			} else if (spawnType > 2 && spawnType <= 3) {
				if(xSpawnPoint + spawnAdjust - 5f <= minSpawnPoint.x) {
					spawnAdjust = 0f;
				} else {
					spawnAdjust = spawnAdjust - 5f;
				}
			} else if (spawnType > 3 && spawnType <= 5) {
				spawnAdjust = 0f;
				xSpawnPoint = Random.Range (minSpawnPoint.x + 3, maxSpawnPoint.x - 3);
			}*/
			xSpawnPoint = Random.Range (minSpawnPoint.x + 0.4f, maxSpawnPoint.x - 0.4f);
			GameObject e = fighter;
			if(phase == 0) {
				e = (GameObject)Instantiate (fighter);
			} else if(phase == 1) {
				if(type >= 50) {
					e = (GameObject)Instantiate (bomber);
				} else {
					e = (GameObject)Instantiate (fighter);
				}
			} else if(phase == 2) {
				if(type <= 33) {
					e = (GameObject)Instantiate (bomber);
				} else if(33 < type && type <= 66) {
					e = (GameObject)Instantiate (fighterAce);
				} else if(type > 66) {
					e = (GameObject)Instantiate (fighter);
				}
			} else if(phase == 3) {
				if(type <= 25) {
					e = (GameObject)Instantiate (bomberAce);
				} else if(type > 25 && type <= 50) {
					e = (GameObject)Instantiate (fighterAce);
				} else if(type > 50 && type <= 75) {
					e = (GameObject)Instantiate (fighter);
				} else if(type > 75) {
					e = (GameObject)Instantiate (bomber);
				}
			} else if(phase == 4) {
				if(type <= 50) {
					e = (GameObject)Instantiate (bomberAce);
				} else if(type > 50) {
					e = (GameObject)Instantiate (fighterAce);
				} 
			} else if(phase == 6) {
				e = (GameObject)Instantiate (mine);
			}
			                      
			maxSpawnPoint = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
			e.transform.position = new Vector2 (xSpawnPoint + spawnAdjust, maxSpawnPoint.y+1);

			enemiesAlive++;
			enemiesLeft--;
			print (enemiesAlive);
			print (enemiesLeft);
			yield return new WaitForSeconds(wait);
		}
	}
}
