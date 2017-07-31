using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FarmDatabase : MonoBehaviour
{
	public List<Farm> farms = new List<Farm>();

	//Add items to the farm list.
	void Start()
	{
		farms.Add(new Farm("Toppin Family", 1, false, "" ) );
		farms.Add(new Farm("Rellan Family", 2, false, "" ) );
		farms.Add(new Farm("Agiss Family",  3, false, "" ) );
		farms.Add(new Farm("Corly Family",  4, false, "" ) );
		farms.Add(new Farm("Bander Family", 5, false, "" ) );
		farms.Add(new Farm("Chemil Family", 6, false, "" ) );
		farms.Add(new Farm("Esters Family", 7, false, "" ) );
		farms.Add(new Farm("Dunns Family",  8, false, "" ) );
		farms.Add(new Farm("Mest Family",   9, false, "" ) );
		farms.Add(new Farm("Aster Family",  10, false,"" ) );
		farms.Add(new Farm("Sunter Family", 11, false,"" ) );
		farms.Add(new Farm("Ennis Family",  12, false,"" ) );
	}
}
