using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour {

	public Transform player;
	public Transform cam;
	public Transform deathCanvas;

	void Awake () {
		//player.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), 0);
		//cam.position = new Vector3(PlayerPrefs.GetFloat("Cam_x"), PlayerPrefs.GetFloat("Cam_y"), PlayerPrefs.GetFloat("Cam_z"));
	}

	public void SaveGameSettings(bool quit) {
		PlayerPrefs.SetFloat("x", player.position.x);
		PlayerPrefs.SetFloat("y", player.position.y);
		PlayerPrefs.SetFloat("Cam_y", cam.position.y);
		PlayerPrefs.SetFloat("Cam_x", cam.position.x);
		PlayerPrefs.SetFloat("Cam_z", cam.position.z);

		if (quit) {
			Time.timeScale = 1;
			SceneManager.LoadScene("Menu");
		}
	}

	public void RestartLevel() {
		SceneManager.LoadScene("Level1");
		deathCanvas.gameObject.SetActive(false);
		Time.timeScale = 1;
	}

	public void QuitToMenuWithoutSave() {
		SceneManager.LoadScene("Menu");
	}
}
