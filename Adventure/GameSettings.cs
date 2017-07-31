using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour
{
	//Game Completion Settings
	public static int percentCompleted = 0;//  100%
	public const int percentFarm = 2;   //12 = 24
	public const int percentVillage = 5;// 2 = 10
	public const int percentItem = 3;   // 6 = 18
	public const int percentJournal = 2;//12 = 24
	public const int percentMemory = 2; //12 = 24

	//Object Counts
	public const int numOfFarms = 12;
	public const int numOfVillages = 2;
	public const int numOfJournals = 12;
	public const int numOfMemories = 12;
	public const int numOfInventory = numOfJournals + numOfMemories;
	public const int numOfItems = 6;

	//Journal Settings
	public static int GUICurrent = 0; //Default to Nothing
	public const int GUIFarms = 1;
	public const int GUIJournals = 2;
	public const int GUIMemories = 3;
	public const int GUIStats = 4; //Show on all menus until something is clicked

}