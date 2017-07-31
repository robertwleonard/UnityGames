using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Destroyer : MonoBehaviour {
	public int amount;
	int count;
	public Transform winCanvas;
	public Text countText;
	public Transform loseCanvas;

	void Start (){
		Time.timeScale = 1f;
		count = 0;
		countText.text  = "0/"+amount;
		winCanvas.gameObject.SetActive (false);
		loseCanvas.gameObject.SetActive (false);
	}

	private void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Collectable")
		{
			Destroy (other.gameObject);
			count++;

			if (count == amount)
				WinScenario ();

			countText.text = count + "/"+amount;

		}
		else if (other.tag == "Enemy")
		{
			LoseScenario ();
		}
	}

	public void WinScenario()
	{
		Time.timeScale = 0f;
		winCanvas.gameObject.SetActive (true);
	}
	public void LoseScenario()
	{
		Time.timeScale = 0f;
		loseCanvas.gameObject.SetActive (true);
	}
}
