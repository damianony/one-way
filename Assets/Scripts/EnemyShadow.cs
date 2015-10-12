using UnityEngine;
using System.Collections;

public class EnemyShadow : MonoBehaviour {
	public GameObject o;
	// Update is called once per frame
	void Update () {
		Vector3 oPosition = o.transform.position;
		transform.position = new Vector3(oPosition.x - 0.12f, oPosition.y + 0.08f, oPosition.z + 2);
	}
}
