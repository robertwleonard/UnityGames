using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldController : MonoBehaviour {

	public int totalGold;
	public int currentGold;
	public Transform winCanvas;
	public AudioClip winSound;

	public Text goldCoinCounter;

	void Start () {
		currentGold = 0;
		goldCoinCounter.text = currentGold.ToString();
	}

	public void AddGold () {
		currentGold += 1;
		totalGold += 1;
		goldCoinCounter.text = currentGold.ToString();

		if ( currentGold == 10 ) {
			if (winCanvas.gameObject.activeInHierarchy == false ) {
				winCanvas.gameObject.SetActive(true);
				Time.timeScale = 0;
				GameObject sound = GameObject.Find("Music");
				AudioSource audio = sound.GetComponent<AudioSource>();
				audio.Stop();
				AudioSource.PlayClipAtPoint(winSound, transform.position, 1f);
			}
		}
	}

	public int GetCurrentGold () {
		return currentGold;
	}
}
