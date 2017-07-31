using UnityEngine;
using System.Collections;

public class Cleaner : MonoBehaviour {
	
	void OnTriggerEnter (Collider other) {
		if ( other.tag == "Player" ) {
			PlayerHealth playerDead = other.gameObject.GetComponent<PlayerHealth>();
			playerDead.MakeDead();
		}
		else
			Destroy(gameObject);
	}
}