using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
	
	public float fullHealth;
	public GameObject playerDeathFX;
	public Transform canvas;
	public AudioClip deathSound;
	
	float currentHealth;
	GameObject sound;
	AudioSource audio;
	
	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		sound = GameObject.Find("Music");
		audio = sound.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void AddDamage (float damage) {
		currentHealth -= damage;
		
		if ( currentHealth <= 0 ) {
			MakeDead();
		}
	}
	
	public void MakeDead() {
		Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
		audio.Stop();
		AudioSource.PlayClipAtPoint(deathSound, transform.position, 1f);
		Destroy(gameObject);

		if (canvas.gameObject.activeInHierarchy == false ) {
			canvas.gameObject.SetActive(true);
			Time.timeScale = 0;
		}
	}
}