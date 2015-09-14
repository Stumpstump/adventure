using UnityEngine;
using System.Collections;

public class EvilGirlDialogue : NpcDialogue 
{
	public delegate void OnDialogueEnter3(string dial, float dialogueTime, Font font);
	public static event OnDialogueEnter3 onDialogue3;
	
	public delegate void OnDialogueExit3();
	public static event OnDialogueExit3 onDialogueExit3;
	
	public string altDialogue;
	public Font altFont;
	public float altTime;
	
	public string desiredObject;
	public Collider2D keyCollider;

	public override void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player" && this != null)
		{
			if(other.GetComponent<Inventory> ().collected.Contains(desiredObject))
			{
				if(keyCollider != null) keyCollider.enabled = true;
				if(onDialogue3 != null) onDialogue3(altDialogue, altTime, altFont);
			}
			else
			{
				if(keyCollider != null) keyCollider.enabled = false;
				if(onDialogue3 != null) onDialogue3(dialogue, dialogueTime, font);
			}
			
		}
	}
	
	public override void OnTriggerExit2D (Collider2D other)
	{
		if(this != null) base.OnTriggerExit2D (other);
	}	
}