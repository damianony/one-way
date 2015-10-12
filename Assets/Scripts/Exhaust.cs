using UnityEngine;
using System.Collections;

public class Exhaust : MonoBehaviour {
	public GameObject player;
	// Update is called once per frame
	void Update () {
		Vector3 playerPosition = player.transform.position;
		transform.position = new Vector3(playerPosition.x, playerPosition.y - 0.30f,playerPosition.z);
	}
}
