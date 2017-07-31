using UnityEngine;
using System.Collections;

[System.Serializable]
public class Farm
{

	public string farmName;
	public bool farmDiscovered;
	public int farmOrder = 0;
	public string farmDesc;

	//Used to add farms
	public Farm ( string name, int order, bool discovered, string description )
	{
		farmName = name;
		farmOrder = order;
		farmDiscovered = discovered;
		farmDesc = description;
	}
	
	public Farm()
	{
		
	}
}
