using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour 
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
