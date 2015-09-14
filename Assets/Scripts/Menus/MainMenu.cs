using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public delegate void OnResume(string levelName, string doorName);
	public static event OnResume onResume;

	public Button resumeButton;
	public Button newGameButton;
	public Button quitButton;

	public GameObject quitPopupRoot;
	public GameObject newGamePopup;
	public GameObject root;


	private void ResumeGame()
	{
		onResume (PlayerPrefs.GetString("level"), 
		          PlayerPrefs.GetString("door"));

		root.SetActive (false);
	}


	private void OpenQuitPopup()
	{
		quitPopupRoot.SetActive (true);
	}


	private void OpenNewGamePopup()
	{
		newGamePopup.SetActive (true);
	}


	private void Awake () 
	{
		resumeButton.onClick.AddListener (ResumeGame);
		newGameButton.onClick.AddListener (OpenNewGamePopup);
		quitButton.onClick.AddListener (OpenQuitPopup);
	}

}
