using UnityEngine;
using System.Collections;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
	//--------------------------------
	// 1 - Designer variables
	//--------------------------------
	
	/// <summary>
	/// Projectile prefab for shooting
	/// </summary>
	public Transform shotPrefab;
	public float bulletSpeed = 1;
	public float chance = 1f;
	
	/// <summary>
	/// Cooldown in seconds between two shots
	/// </summary>
	public float shootingRate = 0.75f;
	
	//--------------------------------
	// 2 - Cooldown
	//--------------------------------
	
	private float shootCooldown;
	
	void Start()
	{
		shootCooldown = 0f;
	}
	
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}
	
	//--------------------------------
	// 3 - Shooting from another script
	//--------------------------------
	
	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			float fire = Random.Range(0.0f,1.0f);
			shootCooldown = shootingRate;

			if(chance >= fire) {
				// Create a new shot
				var shotTransform = Instantiate(shotPrefab) as Transform;
				
				// Assign position
				shotTransform.position = transform.position;
				
				// The is enemy property
				ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
				if (shot != null)
				{
					shot.isEnemyShot = isEnemy;
				}
				
				// Make the weapon shot always towards it
				MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
				if (move != null)
				{
					move.direction = this.transform.up * bulletSpeed; // towards in 2D space is the right of the sprite
				}
			}
		}
	}
	
	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
	/*
	public IEnumerator rapidFire() {
		shootingRate = 0.05f;
		yield return new WaitForSeconds(5);
		shootingRate = 0.2f;
	}

	public IEnumerator laserBeam() {
		shootingRate = 0.01f;
		bulletSpeed = 10;
		yield return new WaitForSeconds(5);
		shootingRate = 0.2f;
		bulletSpeed = 3;
	}

	public IEnumerator megaBlaster() {
		shootingRate = 0.001f;
		bulletSpeed = 10;
		yield return new WaitForSeconds(5);
		shootingRate = 0.2f;
		bulletSpeed = 3;
	}*/
}
