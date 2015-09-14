using UnityEngine;
using System.Collections;

public class InteractibleObject : MonoBehaviour 
{
	public bool activated = false;
	public bool canInteract = false;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			canInteract = true;
		}
	}
	
	
	private void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			canInteract = false;
		}
	}


	private void Update()
	{
		if(canInteract && Input.GetKeyDown(KeyCode.E)) activated = true;
		
	}
}
