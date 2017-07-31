using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour
{
	
	public AudioClip lockedSound;
	public GUIText textHints;
	public Light doorLight;
	
	void OnTriggerEnter( Collider col )
	{
		if ( col.gameObject.tag == "Player" ) {
			if (Inventory.charge == 4 ) {
				transform.FindChild("door").SendMessage("DoorCheck");
				
				if ( GameObject.Find ("PowerGUI") ) {
					Destroy(GameObject.Find("PowerGUI"));
					doorLight.color = Color.green;
				}
			} else if ( Inventory.charge > 0 && Inventory.charge < 4 ) {
				textHints.SendMessage("ShowHint", "The door still won't budge...\nThe generator isn't fully charged yet.");
				transform.FindChild("door").audio.PlayOneShot(lockedSound);
			} else {
				transform.FindChild("door").audio.PlayOneShot(lockedSound);
				col.gameObject.SendMessage("HUDon");
				textHints.SendMessage("ShowHint", "This door hasn't the energy to open.\nFinding some power cells should do the trick.");
			}
		}
	}
}
