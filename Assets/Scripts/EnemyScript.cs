using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour
{
	private bool hasSpawn;
	private MoveScript moveScript;
	private WeaponScript[] weapons;
	
	void Awake()
	{
		// Retrieve the weapon only once
		weapons = GetComponentsInChildren<WeaponScript>();
		
		// Retrieve scripts to disable when not spawn
		moveScript = GetComponent<MoveScript>();
	}
	
	// 1 - Disable everything
	void Start()
	{
		hasSpawn = false;
		
		// Disable everything
		// -- collider
		GetComponent<Collider2D>().enabled = false;
		// -- Moving
		moveScript.enabled = false;
		// -- Shooting

		foreach (WeaponScript weapon in weapons)
		{
			weapon.enabled = false;
		}
	}
	
	void Update()
	{
		// 2 - Check if the enemy has spawned.
		Vector2 maxSpawnPoint = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		Vector2 minSpawnPoint = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		moveScript.enabled = true;
		//moveScript.enabled = true;
		if (hasSpawn == false)
		{
			if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))// || 
			    //gameObject.transform.position.y <= maxSpawnPoint.y+4)
			{
				Spawn();
			}
		}
		else
		{
			// Auto-fire
			foreach (WeaponScript weapon in weapons)
			{
				if (weapon != null && weapon.enabled && weapon.CanAttack)
				{
					weapon.Attack(true);
					SoundEffectsHelper.Instance.MakeEnemyShotSound();
				}
			}
			
			// 4 - Out of the camera ? Destroy the game object.
			if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)// && 
			    //gameObject.transform.position.y < minSpawnPoint.y)
			{
				EnemyWaves.enemiesAlive--;

				/*if(PlayerScript.cityHealth > 0) {
					PlayerScript.cityHealth--;
				}*/

				Destroy(gameObject);
			}
		}
	}
	
	// 3 - Activate itself.
	private void Spawn()
	{
		hasSpawn = true;
		
		// Enable everything
		// -- Collider
		GetComponent<Collider2D>().enabled = true;
		// -- Moving
		moveScript.enabled = true;
		// -- Shooting
		foreach (WeaponScript weapon in weapons)
		{
			weapon.enabled = true;
		}
	}
}
