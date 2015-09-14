using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour 
{
	public Transform top;
	public Transform bottom;

	public float desiredTime;

	private bool canInteract = false;


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


	private void Activate()
	{
		if (transform.position == top.transform.position) 
		{
			StartCoroutine(MoveElevator (top.position, bottom.position));
		} 
		else 
		{
			StartCoroutine(MoveElevator (bottom.position, top.position));
		}
	}


	private IEnumerator MoveElevator(Vector3 startPos, Vector3 endPos)
	{
		float elapsedTime = 0f;
		while(elapsedTime < desiredTime)
		{
			gameObject.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime/desiredTime);

			elapsedTime += Time.deltaTime;
			yield return null;
		}

		gameObject.transform.position = endPos;
	}


	private void Update()
	{
		if(canInteract && Input.GetKeyDown(KeyCode.E)) Activate();

	}
}
