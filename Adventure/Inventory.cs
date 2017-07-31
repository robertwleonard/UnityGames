using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
	//Visited Farm Variables
	public static int farmsVisited = 0;
	public static int villagesVisited = 0;
	private FarmDatabase farmDB; //Compare to the DB values
	public List<Farm> farmlist = new List<Farm>();

	//Villages
	public static string villageOne = "Multon Village";
	public static string villageTwo = "Bartiss Village";
	public static bool visitedVillageOne = false;
	public static bool visitedVillageTwo = false;
	
	//GUI Display
	public GUISkin skin;
	public List<Journal> inventory = new List<Journal>();
	private JournalDatabase database;
	public Rect journalPosition;
	public Rect journalListings;
	public Rect journalContent;
	private bool showInventory = false;
	private bool showTooltip;
	private string tooltip;
	[SerializeField]
	MouseLook mouseLookFPS;
	[SerializeField]
	MouseLook mouseLookMC;

	void Start ()
	{
		farmsVisited = 0;
		villagesVisited = 0;

		//Set up all the Lists
		for ( int i = 0 ; i < GameSettings.numOfInventory ; i++ )
		{
			//slots.Add(new Journal());
			inventory.Add(new Journal());
		}

		for ( int j = 0 ; j < GameSettings.numOfFarms ; j++ )
			farmlist.Add (new Farm() );
		
		database = GameObject.FindGameObjectWithTag("JournalDatabase").GetComponent<JournalDatabase>();
		farmDB = GameObject.FindGameObjectWithTag("FarmDatabase").GetComponent<FarmDatabase>();

		//Go ahead and move all the values from the DB to the lists
		for ( int l = 0 ; l < inventory.Count ; l++ )
			inventory[l] = database.journals[l];

		for ( int k = 0 ; k < farmlist.Count ; k++ )
			farmlist[k] = farmDB.farms[k];

	}
	
	void Update()
	{
		//Get some menu GUI keys
		if ( Input.GetButtonDown("Journal") )
		{
			if ( !showInventory ) showInventory = true;

			if ( showInventory && GameSettings.GUICurrent == GameSettings.GUIJournals )
			{
				showInventory = !showInventory;
				GameSettings.GUICurrent = 0;
				mouseLookMC.enabled = true;
				mouseLookFPS.enabled = true;
				showTooltip = false;
				return;
			}

			GameSettings.GUICurrent = GameSettings.GUIJournals;
			showTooltip = false;

			//When the journal is active, make sure the camera stops panning.
			if ( showInventory )
			{
				mouseLookMC.enabled = false;
				mouseLookFPS.enabled = false;
			}
		}

		if ( Input.GetButtonDown("Farms") )
		{
			if ( !showInventory ) showInventory = true;
			
			if ( showInventory && GameSettings.GUICurrent == GameSettings.GUIFarms )
			{
				showInventory = !showInventory;
				GameSettings.GUICurrent = 0;
				mouseLookMC.enabled = true;
				mouseLookFPS.enabled = true;
				showTooltip = false;
				return;
			}

			GameSettings.GUICurrent = GameSettings.GUIFarms;
			showTooltip = false;
			
			//When the journal is active, make sure the camera stops panning.
			if ( showInventory )
			{
				mouseLookMC.enabled = false;
				mouseLookFPS.enabled = false;
			}
		}

		if ( Input.GetButtonDown("Memory") )
		{
			if ( !showInventory ) showInventory = true;
			
			if ( showInventory && GameSettings.GUICurrent == GameSettings.GUIMemories )
			{
				showInventory = !showInventory;
				GameSettings.GUICurrent = 0;
				mouseLookMC.enabled = true;
				mouseLookFPS.enabled = true;
				showTooltip = false;
				return;
			}

			GameSettings.GUICurrent = GameSettings.GUIMemories;
			showTooltip = false;
			
			//When the journal is active, make sure the camera stops panning.
			if ( showInventory )
			{
				mouseLookMC.enabled = false;
				mouseLookFPS.enabled = false;
			}
		}
	}

	//When the user pulls up the Journal GUI
	void OnGUI()
	{
		tooltip = "";
		GUI.skin = skin;


		if ( showInventory )
		{
			GUI.Box( new Rect( Screen.width  * journalPosition.x, Screen.height * journalPosition.y,
			                   Screen.width * journalPosition.width, Screen.height * journalPosition.height ),
			        			"", skin.GetStyle("Journal") );

			if ( GUI.Button( new Rect(Screen.width  * .3f, Screen.height * .22f, Screen.width * .1f, Screen.height * .07f), "Farms" ) )
				GameSettings.GUICurrent = GameSettings.GUIFarms;

			if ( GUI.Button( new Rect(Screen.width  * .45f, Screen.height * .22f, Screen.width * .1f, Screen.height * .07f), "Memories" ) )
				GameSettings.GUICurrent = GameSettings.GUIMemories;

			if ( GUI.Button( new Rect(Screen.width  * .60f, Screen.height * .22f, Screen.width * .1f, Screen.height * .07f), "Journals" ) )
				GameSettings.GUICurrent = GameSettings.GUIJournals;

			//Switch into the correct menu
			switch ( GameSettings.GUICurrent )
			{
			case GameSettings.GUIFarms:
				DrawFarmRect();
				break;
			case GameSettings.GUIJournals:
				DrawJournalRect();
				break;
			case GameSettings.GUIMemories:
				DrawMemoryRect();
				break;
			//case GameSettings.GUIStats:
			//	DrawStatsRect();
			//	break;
			default: //Shouldn't happen, but if it does then just turn off the inventory
				showInventory = !showInventory;
				break;
			}
		}

		//Change this to a click event, instead of a mouseover
		if ( showTooltip )
		{
			GUI.Box( new Rect( Screen.width  * journalContent.x, Screen.height * journalContent.y,
			                  Screen.width * journalContent.width, Screen.height * journalContent.height ),
			        		   tooltip, skin.GetStyle("Tooltip") );
		}
	}
	
	//Draw the Farm GUI
	void DrawFarmRect()
	{
		int i = 0;
		float gui_height;
		bool farmsFound = false;

		for ( int l = 0 ; l < farmlist.Count ; l++ )
		{
			if ( i == 0 )
				gui_height = Screen.height * journalListings.y;
			else if ( i == farmlist.Count-1 && !farmsFound ) //Nothing Found goes on top also
				gui_height = Screen.height * journalListings.y;
			else
				gui_height = (Screen.height * journalListings.y) + (l*25);

			Rect farmRect = new Rect(Screen.width * journalListings.x, gui_height, Screen.width*journalListings.width, Screen.height * journalListings.height);
			GUI.Box( farmRect, "", skin.GetStyle("Slot") );

			if ( farmlist[i].farmDiscovered )
			{
				if ( GUI.Button( farmRect, farmlist[i].farmName, skin.GetStyle("Slot") ) )
				{
					showTooltip = !showTooltip;
				}
				//GUI.TextArea( farmRect, "<color=#fff>" + farmlist[i].farmName + " Farm</color>", skin.GetStyle("Slot") );
				farmsFound = true;
			}

			//If nothing found by the end, show them it's empty.
			if ( i == farmlist.Count-1 && !farmsFound )
				GUI.TextArea( farmRect, "<color=#fff>No Farms\nDiscovered</color>", skin.GetStyle("Slot"));

			i++;
		}
	}

	//Draw the Journal GUI
	void DrawJournalRect()
	{
		int i = 0;
		int found = 0;
		float gui_height;
		bool journalFound = false;
		
		for ( int j= 1 ; j < GameSettings.numOfInventory+1 ; j++ )
		{
			if ( found == 0 )
				gui_height = Screen.height * journalListings.y;
			else if ( found == GameSettings.numOfInventory-1 && !journalFound ) //Nothing Found goes on top also
				gui_height = Screen.height * journalListings.y;
			else
				gui_height = (Screen.height * journalListings.y) + (found*35);
			
			Rect journalRect = new Rect(Screen.width * journalListings.x, gui_height, Screen.width*journalListings.width, Screen.height * journalListings.height);
			GUI.Box( journalRect, "", skin.GetStyle("Slot") );
			
			if ( inventory[i].journalFound )
			{
				if ( inventory[i].journalType == Journal.JournalType.Quest )
				{
					GUI.TextArea( journalRect, "<color=#fff>" + inventory[i].journalName + "</color>", skin.GetStyle("Slot") );
					journalFound = true;
					found++;

					if ( journalRect.Contains(Event.current.mousePosition) )
					{
						tooltip = CreateTooltip( inventory[i]);
						showTooltip = true;
					}
				}
			}

			if ( tooltip == "" )
			{
				showTooltip = false;
			}
			
			//If nothing found by the end, show them it's empty.
			if ( i == GameSettings.numOfInventory-1 && !journalFound )
				GUI.TextArea( journalRect, "<color=#fff>No Journals\nDiscovered</color>", skin.GetStyle("Slot"));
			
			i++;
		}
	}

	//Draw the Memory GUI
	void DrawMemoryRect()
	{
		int i = 0;
		int found = 0;
		float gui_height;
		bool journalFound = false;
		
		for ( int j= 1 ; j < GameSettings.numOfInventory+1 ; j++ )
		{
			if ( found == 0 )
				gui_height = Screen.height * journalListings.y;
			else if ( found == GameSettings.numOfInventory-1 && !journalFound ) //Nothing Found goes on top also
				gui_height = Screen.height * journalListings.y;
			else
				gui_height = (Screen.height * journalListings.y) + (found*35);
			
			Rect journalRect = new Rect(Screen.width * journalListings.x, gui_height, Screen.width*journalListings.width, Screen.height * journalListings.height);
			GUI.Box( journalRect, "", skin.GetStyle("Slot") );
			
			if ( inventory[i].journalFound )
			{
				if ( inventory[i].journalType == Journal.JournalType.Memory )
				{
					GUI.TextArea( journalRect, "<color=#fff>" + inventory[i].journalName + "</color>", skin.GetStyle("Slot") );
					journalFound = true;
					found++;

					if ( journalRect.Contains(Event.current.mousePosition) )
					{
						tooltip = CreateTooltip( inventory[i]);
						showTooltip = true;
					}
				}
			}

			if ( tooltip == "" )
			{
				showTooltip = false;
			}
			
			//If nothing found by the end, show them it's empty.
			if ( i == GameSettings.numOfInventory-1 && !journalFound )
				GUI.TextArea( journalRect, "<color=#fff>No Memories\nDiscovered</color>", skin.GetStyle("Slot"));

			i++;
		}
	}
	
	//Show more information about the journal entries
	string CreateTooltip ( Journal journal )
	{
		tooltip = "<color=#fff>" + journal.journalDesc + "</color>";
		return tooltip;
	}

	//Add a journal when it's walked over. (JournalCollect.cs)
	public void AddItem( int id )
	{
		for ( int i = 0 ; i < inventory.Count ; i++ )
		{
			if ( inventory[i].journalID == id )
			{
				inventory[i].journalFound = true;

				//Make sure to only add the correct JournalType
				if ( inventory[i].journalType == Journal.JournalType.Memory )
				    GameSettings.percentCompleted += GameSettings.percentMemory;

				if ( inventory[i].journalType == Journal.JournalType.Quest )
					GameSettings.percentCompleted += GameSettings.percentJournal;

				GetComponent<AudioSource>().PlayOneShot(inventory[i].journalAudioName);
				Debug.Log( GameSettings.percentCompleted );
				break;
			}
		}
	}

	//Add a farm to the farmlist (VisitedFarm.cs)
	public void AddFarm( int order )
	{
		for ( int i = 0 ; i < farmlist.Count ; i++ )
		{
			if ( farmlist[i].farmOrder == order )
			{
				farmlist[i].farmDiscovered = true;
				GameSettings.percentCompleted += GameSettings.percentFarm;
				Debug.Log( GameSettings.percentCompleted );
				break;
			}
		}
	}

	//Return the name of a farm (VisitedFarm.cs)
	public string GetFarmName( int order )
	{
		string farm_name = "";

		for ( int i = 0 ; i < farmlist.Count ; i++ )
		{
			if ( farmlist[i].farmOrder == order )
			{
				farm_name = farmlist[i].farmName;
				break;
			}
		}

		return farm_name;

	}

	//Check if they've found a journal yet
	bool InventoryContains( int id )
	{
		foreach( Journal journal in inventory )
		{
			if(journal.journalID == id)
				return true;
		}
		
		return false;
	}
	
	//Not needed in this game, but good practice
	void RemoveItem( int id )
	{
		for ( int i = 0 ; i < inventory.Count ; i++ )
		{
			//Fill a full slot with an empty one
			if ( inventory[i].journalID == id )
			{
				inventory[i] = new Journal();
				break;
			}
		}
	}
}





/*
//This is all too much, simplifying it.
//Still needs to show memory sequences (maybe 2 tabs based on enum JournalTyle)
void DrawInventory( bool is_journal )
{
	int i = 0, j = 0; //j will need to format the GUI
	int gui_height;
	bool inventoryFound = false;
	
	//Loop through the # of journal slots (public int)
	for ( int y = 0 ;  y < slotsY ; y++ )
	{
		if ( j == 0 )
			gui_height = 200;
		else if ( j == slotsY-1 && !inventoryFound ) //Nothing Found goes on top also
			gui_height = 200;
		else
			gui_height = 200 + (j*45);
		
		Rect slotRect = new Rect( Screen.width / 2 + 220, gui_height, 300, 50);
		GUI.Box( slotRect, "", skin.GetStyle("Slot"));
		
		slots[i] = inventory[i];
		
		//I think all this can be simplified really. Another List doesn't seem necessary
		if ( slots[i].journalName != null )
		{
			//Seems better, but this is looping endlessly hrmmm..
			//if ( showJournal && (slots[i].journalType == Journal.JournalType.Memory) )
			//	continue;
			
			//if ( !showJournal && (slots[i].journalType == Journal.JournalType.Quest) )
			//	continue;
			
			if ( !is_journal && (slots[i].journalType == Journal.JournalType.Memory) )
			{
				GUI.TextArea( slotRect, "<color=#fff>" + slots[i].journalName + "</Color>", skin.GetStyle("Slot"));
				inventoryFound = true;
				
				if ( slotRect.Contains(Event.current.mousePosition) )
				{
					tooltip = CreateTooltip( slots[i]);
					showTooltip = true;
				}
			}
			else if ( is_journal && (slots[i].journalType == Journal.JournalType.Quest) )
			{
				GUI.TextArea( slotRect, "<color=#fff>" + slots[i].journalName + "</Color>", skin.GetStyle("Slot"));
				inventoryFound = true;
				
				if ( slotRect.Contains(Event.current.mousePosition) )
				{
					tooltip = CreateTooltip( slots[i]);
					showTooltip = true;
				}
			}
		}
		
		if ( tooltip == "" )
		{
			showTooltip = false;
		}
		
		//j only goes up if the type matches
		if ( !is_journal && (slots[i].journalType == Journal.JournalType.Memory) )
			j++;
		else if ( is_journal && (slots[i].journalType == Journal.JournalType.Quest) )
			j++;
		
		//If nothing found by the end, show them it's empty.
		if ( i == slotsY-1 && !inventoryFound )
			GUI.TextArea( slotRect, "<color=#fff>No Journals\nDiscovered</color>", skin.GetStyle("Slot"));
		
		i++;
	}
} */

