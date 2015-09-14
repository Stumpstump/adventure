using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public static string targetDoorId;
	public Transform player;
	public Text text;


	private void Resume(string level, string door)
	{
		targetDoorId = door;
		Application.LoadLevel (level);
	}


	private void NewGame()
	{
		PlayerPrefs.SetString ("door", "level1door1");
		targetDoorId = "level1door1";

		Application.LoadLevel("level1");
	}


	private void OnLevelWasLoaded(int level) 
	{
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		PlayerPrefs.SetString ("level", Application.loadedLevelName);
		PlayerPrefs.SetString ("door", targetDoorId);
		Door[] doors = GameObject.FindObjectsOfType(typeof(Door)) as Door[];	
		foreach(Door door in doors)
		{
			if(door.Id == targetDoorId)
			{
				player.position = door.spawnPos.position;
				break;
			}
		}
	}



	private void Awake () 
	{
		if(PlayerPrefs.GetInt ("keycount") == null) PlayerPrefs.SetInt ("keycount", 0);
		if(string.IsNullOrEmpty(PlayerPrefs.GetString ("level"))) PlayerPrefs.SetString ("level", "level1");
		if(string.IsNullOrEmpty(PlayerPrefs.GetString ("door"))) 
		{
			PlayerPrefs.SetString ("door", "level1door1");
			targetDoorId = "level1door1";
		}
		else
		{
			targetDoorId = PlayerPrefs.GetString ("door");
		}

		MainMenu.onResume += Resume;
		DontDestroyOnLoad (gameObject);
	}
}
