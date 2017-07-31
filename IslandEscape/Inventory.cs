using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
	
	public static int charge = 0;
	public AudioClip collectSound;
	//HUD
	public Texture2D[] hudCharge;
	public GUITexture chargeHudGUI;
	//Matches
	bool haveMatches = false;
	bool fireIsLit = false;
	public GUITexture matchGUIprefab;
	GUITexture matchGUI;
	public GUIText textHints;
	//Genertor
	public Texture2D[] meterCharge;
	public Renderer meter;
	public GameObject winObj;
	
	// Use this for initialization
	void Start ()
	{
		charge = 0;
	}

	void CellPickup()
	{
		HUDon();
		AudioSource.PlayClipAtPoint( collectSound, transform.position );
		charge++;
		chargeHudGUI.texture = hudCharge[charge];
		meter.material.mainTexture = meterCharge[charge];
	}
	
	void HUDon()
	{
		if ( !chargeHudGUI.enabled)
		{
			chargeHudGUI.enabled = true;
		}
	}

	void MatchPickup()
	{
		haveMatches = true;
		AudioSource.PlayClipAtPoint( collectSound, transform.position);
		GUITexture matchHUD = Instantiate( matchGUIprefab, new Vector3(0.15f, 0.1f, 0), transform.rotation) as GUITexture;
		matchGUI = matchHUD;
	}

	void OnControllerColliderHit(ControllerColliderHit col)
	{
		if (col.gameObject.name == "campfire")
		{
			if (!haveMatches && !fireIsLit)
			{
				textHints.SendMessage("ShowHint", "I could use this campfire to signal for help\nif I can find something to light it.");
			}
			else if ( !fireIsLit )
			{
				LightFire(col.gameObject);
			} 
		}
	}

	void LightFire( GameObject campfire )
	{
		campfire.GetComponentInChildren<ParticleSystem>().Play();
		Destroy(matchGUI);
		haveMatches = false;
		fireIsLit = true;
		winObj.SendMessage("GameOver");
		campfire.audio.Play();
	}
}
