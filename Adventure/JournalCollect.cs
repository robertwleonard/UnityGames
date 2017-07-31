using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class JournalCollect : MonoBehaviour
{

	public Inventory inventory_add;
	public int journalNumber;
	public AudioClip journalAudio;

	//Player enters a journal box collider, collect it and destroy
	void OnTriggerEnter( Collider c )
	{
		if ( c.gameObject.tag == "Player" )
		{
			if ( inventory_add == null )
				Debug.Log("Can't find the Inventory GameObject.");

			inventory_add.AddItem(journalNumber);
			Destroy(gameObject);
		}
	}
}