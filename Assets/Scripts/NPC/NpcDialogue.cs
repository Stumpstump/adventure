using UnityEngine;
using System.Collections;

public class NpcDialogue : MonoBehaviour 
{
	public delegate void OnDialogueEnter(string dial, float dialogueTime, Font font);
	public static event OnDialogueEnter onDialogue;

	public delegate void OnDialogueExit();
	public static event OnDialogueExit onDialogueExit;

	public string dialogue;
	public float dialogueTime;
	public Font font;


	public virtual void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(this != null) onDialogue(dialogue, dialogueTime, font);
		}
	}


	public virtual void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(this != null) onDialogueExit();
		}
	}
}
