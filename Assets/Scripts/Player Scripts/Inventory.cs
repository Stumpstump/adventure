using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	public List<string> collected = new List<string> ();
	public List<string> collectedInstanceIds = new List<string> ();

	private void pickupItem(string s, string id)
	{
		if(!collectedInstanceIds.Contains(id))
		{
			collected.Add (s);
			collectedInstanceIds.Add (id);
		}
	}


	private void Awake()
	{
		Collectible.pickUp += pickupItem;
	}
}
