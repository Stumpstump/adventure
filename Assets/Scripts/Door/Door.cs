using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Door : MonoBehaviour 
{
	public string Id;

	public string targetId;
	public string targetLevel;

	public Transform spawnPos;

	public ParticleSystem particles;
	public List<KeyHole> keyHoles = new List<KeyHole> ();

	private SpriteRenderer sprite;
	private Inventory playerInventory;
	private bool isOpen;
	private bool canInteract = false;

	public bool IsOpen
	{
		get{ return isOpen; }
		set
		{
			isOpen = value;
			if(isOpen) particles.Play ();
		}
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (IsOpen) 
		{
			canInteract = true;
		}
	}


	private void OnTriggerExit2D(Collider2D other)
	{
		if (IsOpen) 
		{
			canInteract = false;
		}
	}



	private void FillKeyHole(string s, string id)
	{
		if (s == "Key" && this != null) 
		{
			StartCoroutine (FillKeyHoleCoroutine ());
		}
	}


	private IEnumerator FillKeyHoleCoroutine()
	{
		yield return null;
		if (gameObject != null) 
		{
			int keyCount = PlayerPrefs.GetInt("keycount");
			
			for(int i = 0; i < keyHoles.Count; i++)
			{
				if(keyCount > 0)
				{
					keyHoles[i].Filled = true;
					keyCount--;
				}
				else
				{
					break;
				}
			}
			OpenDoor();
		}
	}


	private void OpenDoor()
	{
		foreach(KeyHole kh in keyHoles)
		{
			if(!kh.Filled) return;
		}
		sprite.color = Color.white;
		IsOpen = true;
	}


	private void Update()
	{
		if(canInteract && Input.GetKeyDown(KeyCode.E))
		{
			GameManager.targetDoorId = targetId;
			Application.LoadLevel(targetLevel);
		}
	}
	
	
	private void Awake () 
	{
		StartCoroutine (FillKeyHoleCoroutine ());
		sprite = this.GetComponent<SpriteRenderer> ();
		playerInventory = GameObject.FindObjectOfType<Inventory> ();
		Collectible.pickUp += FillKeyHole;
	}
}
