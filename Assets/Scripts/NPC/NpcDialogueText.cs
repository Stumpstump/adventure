using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NpcDialogueText : MonoBehaviour 
{
	public Text dialogueText;


	private void FillText(string s, float t, Font f)
	{
		if(this != null)
		{
			dialogueText.font = f;
			StartCoroutine (FillTextCoroutine (s, t));
		}
	}


	private void ClearText ()
	{
		if(this != null)
		{
			StopAllCoroutines ();
			dialogueText.text = "";
		}
	}


	private IEnumerator FillTextCoroutine(string s, float t)
	{
		float elapsedTime = 0f;

		char[] charsInString = s.ToCharArray ();
		List<char> currChars = new List<char> (); 

		int totalChars = charsInString.Length;
		int currentChars = 0;

		string temp;

		while (elapsedTime < t)
		{
			temp = "";
			currChars.Clear ();

			currentChars = Mathf.RoundToInt((totalChars * elapsedTime)/t);
			for(int i = 0; i < currentChars; i++)
			{
				temp = temp + charsInString[i].ToString ();
			}

			dialogueText.text = temp;

			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}


	private void OnLevelWasLoaded(int level) 
	{
		ClearText ();
	}


	private void Awake()
	{
		NpcDialogue.onDialogue += FillText;
		NpcDialogue.onDialogueExit += ClearText;

		NpcDialogueQuest.onDialogue2 += FillText;
		NpcDialogueQuest.onDialogueExit2 += ClearText;

		EvilGirlDialogue.onDialogue3 += FillText;
		EvilGirlDialogue.onDialogueExit3 += ClearText;
	}
}
