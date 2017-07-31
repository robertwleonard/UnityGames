using UnityEngine;
using System.Collections;

[System.Serializable]
public class Journal
{

	public string journalName;
	public int journalID = -1;
	public string journalDesc;
	public int journalOrder = -1;
	public bool journalFound = false;
	public JournalType journalType;
	public AudioClip journalAudioName;
	
	public enum JournalType
	{
		Quest,
		Memory
	}
	
	//Used to add journals
	public Journal( string name, int id, string description, int order, bool found, JournalType type, AudioClip audioName )
	{
		journalName = name;
		journalID = id;
		journalDesc = description;
		journalOrder = order;
		journalFound = found;
		journalType = type;
		journalAudioName = audioName;
	}
	
	public Journal()
	{
	
	}
}
