using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name.Equals ("player")) {
			
			//SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}

	}

	public void PlayerDeath()
	{
		Debug.Log ("adawda");
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

}
