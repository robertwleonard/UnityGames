using UnityEngine;
using System.Collections;

public class VisitedVillage : MonoBehaviour
{
	public bool villageVisited = false;
	public int villageNumber;
	public GUIText textHints;

	//Player has entered a farm collider
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			if ( !villageVisited )
			{

				switch ( villageNumber )
				{
				case 2:
					Inventory.visitedVillageTwo = true;
					villageVisited = true;
					textHints.SendMessage("ShowHint", "Discovered " + Inventory.villageTwo );
					GameSettings.percentCompleted += GameSettings.percentVillage;
					break;
				case 1:
					textHints.SendMessage("ShowHint", "Discovered " + Inventory.villageOne );
					Inventory.visitedVillageOne = true;
					villageVisited = true;
					GameSettings.percentCompleted += GameSettings.percentVillage;
					break;
				}

			}
		}
	}
}