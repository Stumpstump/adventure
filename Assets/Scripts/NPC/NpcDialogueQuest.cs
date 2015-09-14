using UnityEngine;
using System.Collections;

public class NpcDialogueQuest : NpcDialogue 
{
	public delegate void OnDialogueEnter2(string dial, float dialogueTime, Font font);
	public static event OnDialogueEnter2 onDialogue2;
	
	public delegate void OnDialogueExit2();
	public static event OnDialogueExit2 onDialogueExit2;

	public string altDialogue;
	public Font altFont;
	public float altTime;

	public string desiredObject;

	public override void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(other.GetComponent<Inventory> ().collected.Contains(desiredObject))
			{
				onDialogue2(altDialogue, altTime, altFont);
			}
			else
			{
				onDialogue2(dialogue, dialogueTime, font);
			}

		}
	}

	public override void OnTriggerExit2D (Collider2D other)
	{
		base.OnTriggerExit2D (other);
	}	
}
