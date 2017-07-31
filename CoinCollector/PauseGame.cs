using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	public Transform canvas;

	GameObject sound;
	AudioSource audio;

	void Start() {
		sound = GameObject.Find("Music");
		audio = sound.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown(KeyCode.Escape)) {
			Pause();
		}
	}

	public void Pause () {
		if (canvas.gameObject.activeInHierarchy == false ) {
			audio.Pause();
			canvas.gameObject.SetActive(true);
			Time.timeScale = 0;
		} else {
			audio.Play();
			canvas.gameObject.SetActive(false);
			Time.timeScale = 1;
		}
	}
}
