using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour 
{
	public delegate void OnPickUp(string s, string id);
	public static event OnPickUp pickUp;

	public string collectibleId;
	public string uniqueKeyId;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			pickUp(collectibleId, uniqueKeyId);
			PlayerPrefs.SetString(uniqueKeyId, collectibleId);
			if(collectibleId == "Key") PlayerPrefs.SetInt("keycount", PlayerPrefs.GetInt("keycount")+1);
			Destroy(gameObject);
		}
	}


	private void Awake()
	{
		if(!string.IsNullOrEmpty(PlayerPrefs.GetString(uniqueKeyId.ToString ())))
		{
			pickUp(collectibleId, uniqueKeyId);
			Destroy(gameObject);
		}
	}
}
