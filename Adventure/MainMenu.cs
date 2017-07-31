using UnityEngine;
using System.Collections;
[RequireComponent (typeof (AudioSource) )]

public class MainMenu : MonoBehaviour {
	
	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect playButton;
	public Rect instructionsButton;
	public Rect loadButton;
	public Rect quitButton;
	Rect menuAreaNormalized;
	string menuPage = "main";
	public Rect instructions;
	
	void Start ()
	{
		menuAreaNormalized = 
			new Rect(menuArea.x * Screen.width - (menuArea.width * 0.5f),
			         menuArea.y * Screen.height - (menuArea.height * 0.5f),
			         menuArea.width, menuArea.height );
	}
	
	void OnGUI() {
		GUI.skin = menuSkin;
		GUI.BeginGroup(menuAreaNormalized);

		//new Rect( Screen.width * playButton.x, Screen.height*playButton.y, Screen.width*playButton.width, Screen.height*playButton.height )

		if ( menuPage == "main")
		{
			if ( GUI.Button(new Rect(Screen.width*playButton.x, Screen.height*playButton.y, Screen.width*playButton.width, Screen.height*playButton.height),
			                "Play") )
			{
				StartCoroutine("ButtonAction", "Intro");
			}
			
			if ( GUI.Button(new Rect(Screen.width*instructionsButton.x, Screen.height*instructionsButton.y, instructionsButton.width, instructionsButton.height),
			                "Options") )
			{
				GetComponent<AudioSource>().PlayOneShot(beep);
				menuPage = "instructions";
			}

			if ( GUI.Button(new Rect(Screen.width*loadButton.x, Screen.height*loadButton.y, Screen.width*loadButton.width, Screen.height*loadButton.height),
			                "Load") )
			{
				menuPage = "load";
			}
			
			if ( GUI.Button(new Rect(Screen.width*quitButton.x, Screen.height*quitButton.y, Screen.width*quitButton.width, Screen.height*quitButton.height),
			                "Quit") )
			{
				StartCoroutine("ButtonAction", "quit");
			}
		}
		else if ( menuPage == "instructions" )
		{
			GUI.Label(new Rect(Screen.width*instructions.x, Screen.height*instructions.y, instructions.width, instructions.height), "Options:\n\n");
			
			if ( GUI.Button( new Rect(Screen.width*instructionsButton.x, Screen.height*instructionsButton.y, instructionsButton.width, instructionsButton.height), "Back"))
			{
				GetComponent<AudioSource>().PlayOneShot(beep);
				menuPage = "main";
			}
		}
		
		GUI.EndGroup();
	}
	
	IEnumerator ButtonAction( string levelName )
	{
		GetComponent<AudioSource>().PlayOneShot(beep);
		yield return new WaitForSeconds(0.35f);
		
		if ( levelName != "quit" )
			Application.LoadLevel(levelName);
		else
		{
			Application.Quit();
			Debug.Log("Have Quit");
		}
	}
}
