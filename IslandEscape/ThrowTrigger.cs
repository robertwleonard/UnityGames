using UnityEngine;
using System.Collections;

public class ThrowTrigger : MonoBehaviour {

	public GUITexture crosshair;
	public GUIText textHints;

	void OnTriggerEnter( Collider col ) {
		if ( col.gameObject.tag == "Player" ) {
			CoconutThrower.canThrow = true;
			crosshair.enabled = true;

			if ( !CoconutWin.haveWon ) {
				textHints.SendMessage ("ShowHint",
					"\n\n\n\n There is a power cell attached to this game,\nmaybe I'll win it if I knock down the targets.");
			}
		}
	}

	void OnTriggerExit( Collider col ) {
		if ( col.gameObject.tag == "Player" ) {
			CoconutThrower.canThrow = false;
			crosshair.enabled = false;
		}
	}
}
