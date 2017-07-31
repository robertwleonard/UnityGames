using UnityEngine;
using System.Collections;

public class GoldCollection : MonoBehaviour {

	GameObject target;
	GoldController goldController;

	public AudioClip coinPickup;
	public float speed = 60f;

	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
		goldController = target.GetComponent<GoldController>();
	}

	void Update () {
		transform.Rotate(0, speed * Time.deltaTime, 0, Space.World);
	}

	void OnTriggerEnter (Collider other) {
		if ( other.tag == "Player" ) {
			Destroy (gameObject);
			AudioSource.PlayClipAtPoint(coinPickup, transform.position, 1f);
			goldController.AddGold();
		}
	}
}
