using UnityEngine;
using System.Collections;

public class VisitedFarm : MonoBehaviour
{
	public Inventory addFarm;
    public GUIText textHints;
	public bool farmVisited;
	public int farmOrder; //To track the database

	//Player has entered a farm collider
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
			if ( !farmVisited )
			{
				if ( addFarm == null )
					Debug.Log("Can't find the Inventory GameObject.");

				//they found a farm, so add it to the inventory and update a GUI
				addFarm.AddFarm(farmOrder);
				Inventory.farmsVisited += 1;
				textHints.SendMessage("ShowHint", "Discovered " + addFarm.GetFarmName(farmOrder) + " Farm" );
				farmVisited = true;
			}
        }
    }
}