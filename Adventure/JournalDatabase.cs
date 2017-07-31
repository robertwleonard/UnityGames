using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JournalDatabase : MonoBehaviour
{
	public List<Journal> journals = new List<Journal>();

	//Don't really like this, would like to add other ways
	void Start()
	{
		//Journals
		journals.Add(new Journal("Queen Kaiyren - Lady Allay", 0,
		                         "\nMy Dearest Irin,\n\nWe shall miss you in Alindrak, my friend. I am sorry that your first task upon returning to your homeland is to investigate these rumors of an uprising. It is my sincerest hope that all will be corrected swiftly so that you may enjoy some much-deserved rest. If any more is discovered in your absence, I shall send word immediately.\n\nIrin, thank you for everything. Your service to this kingdom is unmatched. Yours will be some very big boots to fill indeed. Please write soon.\n\nCordially Yours,\nKaiyren, Queen of Draknor",
		                         1, true, Journal.JournalType.Quest,
		                         Resources.Load("Targets") as AudioClip ));
		journals.Add(new Journal("Jasin Parth - Bandit Activity", 1,
		                         "A journal entry.",
		                         1, false, Journal.JournalType.Quest,
		                         Resources.Load("Targets") as AudioClip ));
		journals.Add(new Journal("Petra Agiss - Abandoned Home", 2,
		                         "A journal entry.",
		                         1, false, Journal.JournalType.Quest,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("Brayden Allay - Targets", 3,
		                         "Nobody wants to admit this is more than the work of bandits. These attacks are just too specific to be coincidence. Everyone we have lost has some relation to my family. Everyone taken or killed follows my bloodline. Why could they be targeting us? Why won't anyone listen?"
		                         ,1, false, Journal.JournalType.Quest,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("Petra Agiss - More Letters of Abandonment", 4,
		                         "A journal entry.",
		                         1, false, Journal.JournalType.Quest,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("Brayden Allay - Multon Is Taken", 5,
		                         "A journal entry.",
		                         1, false, Journal.JournalType.Quest,
		                         Resources.Load("Targets") as AudioClip));


		journals.Add(new Journal("Jasin Parth - Wall Construction Approved", 7,
		                         "A journal entry.",
		                         1, false, Journal.JournalType.Quest,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("Brayden Allay - Reluctant Leader", 8,
		                         "A journal entry.",
		                         1, false, Journal.JournalType.Quest,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("Brayden Allay - First Loss", 9,
		                         "A journal entry.",
		                         1, false, Journal.JournalType.Quest,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("Jasin Parth - We Must Pull Back", 10,
		                         "A journal entry.",
		                         1, false, Journal.JournalType.Quest,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("Brayden Allay - Reinforcements", 11,
		                         "A journal entry.",
		                         1, false, Journal.JournalType.Quest,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("Brayden Allay - Tereton Valley Surrenders", 6,
		                         "A journal entry.",
		                         1, false, Journal.JournalType.Quest,
		                         Resources.Load("Targets") as AudioClip));


		//Memories
		journals.Add(new Journal("Memories of Leaving", 12,
		                         "\nThe first time I left this place I was just a girl, even younger than I thought at the time. I came back with a husband and a child. The Queen was not yet finished with me then, and it was not long before I was called away again.\n\nI was not home when my husband died, and I did not see my child grow.\n\nQueen Kaiyren is not done with me still. Retirement and titles are fine things. Still, they mean more control of this region for the throne. No gift is without reason..",
		                         1, false, Journal.JournalType.Memory,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("Tereton Valley", 13,
		                         "A memory scene.",
		                         1, false, Journal.JournalType.Memory,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("This Place Is So Quiet", 14,
		                         "A memory scene.",
		                         1, false, Journal.JournalType.Memory,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("Brayden's Bow", 15,
		                         "A memory scene.",
		                         1, false, Journal.JournalType.Memory,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("Family Gravestones", 16,
		                         "A memory scene.",
		                         1, false, Journal.JournalType.Memory,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("Wooden Walls of Multon", 17,
		                         "A memory scene.",
		                         1, false, Journal.JournalType.Memory,
		                         Resources.Load("Targets") as AudioClip));

		journals.Add(new Journal("Signs of Struggle", 18,
		                         "A memory scene.",
		                         1, false, Journal.JournalType.Memory,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("Brayden? My Brayden?", 19,
		                         "A memory scene.",
		                         1, false, Journal.JournalType.Memory,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("What Have I Brought Home?", 20,
		                         "A memory scene.",
		                         1, false, Journal.JournalType.Memory,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("Grafton, the Would-be King", 21,
		                         "A memory scene.",
		                         1, false, Journal.JournalType.Memory,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("A Hero's Sword", 22,
		                         "A memory scene.",
		                         1, false, Journal.JournalType.Memory,
		                         Resources.Load("Targets") as AudioClip));
		journals.Add(new Journal("I Will Come For You", 23,
		                         "A memory scene.",
		                         1, false, Journal.JournalType.Memory,
		                         Resources.Load("Targets") as AudioClip));
	}
}
