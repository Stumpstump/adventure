using UnityEngine;
using System.Collections;

public class KeyHole : MonoBehaviour 
{
	private SpriteRenderer sprite;
	private bool filled = false;

	public bool Filled
	{
		get{ return filled; }
		set
		{
			filled = value;
			sprite.color = Color.white;
		}
	}


	private void Start()
	{
		sprite = this.GetComponent<SpriteRenderer> ();
	}
}
