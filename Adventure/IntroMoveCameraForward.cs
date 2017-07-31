using UnityEngine;
using System.Collections;

public class IntroMoveCameraForward : MonoBehaviour
{
	public float mountSpeed;
	public float speed;
	bool moveFoot = false;
	bool moveHorse = false;
	public AudioClip kaiyrenLetter;
	public AudioClip introMusic;
	public AudioClip horses;
	public Fading fadeObj;
	

	// Use this for initialization
	void Start () {
		StartCoroutine( OpeningSequence());
		GetComponent<AudioSource>().PlayOneShot(kaiyrenLetter);
		//audio.PlayOneShot(horses);
	}
	
	// Update is called once per frame
	void Update () {
		if ( moveFoot )
			transform.position += transform.forward * Time.deltaTime * speed;
	}

	IEnumerator OpeningSequence() {
		float fadeTime = fadeObj.BeginFade(1, 10f);
		yield return new WaitForSeconds(fadeTime);
		yield return StartCoroutine( GameIntro() );
	}
	
	IEnumerator GameIntro () {
		moveFoot = true;
		float fadeTime2 = fadeObj.BeginFade(-1, 1.0f);
		yield return new WaitForSeconds(fadeTime2);
		GetComponent<AudioSource>().PlayOneShot(introMusic, 0.5f);
		yield return new WaitForSeconds (34);
		float fadeTime = fadeObj.BeginFade(1, 1.0f);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel("ArgolisHighlands");
	}
}
