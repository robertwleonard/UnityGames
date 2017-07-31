using UnityEngine;
using System.Collections;

public class TextHints : MonoBehaviour
{
	
	float timer = 0.0f;
	
	void Start()
	{
		GetComponent<GUIText>().enabled = false;
	}

	//Makes sure the village name goes away on its own
	void Update ()
	{
		if (GetComponent<GUIText>().enabled)
		{
			timer += Time.deltaTime;
			
			if ( timer >= 5 )
			{
				GetComponent<GUIText>().enabled = false;
				timer = 0.0f;
			}
		}
	}
	
	void ShowHint( string message )
	{
		GetComponent<GUIText>().text = message;
		
		if ( !GetComponent<GUIText>().enabled ) {
			GetComponent<GUIText>().enabled = true;
		}
	}
}
