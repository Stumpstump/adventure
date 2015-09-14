using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGamePopup : MonoBehaviour 
{
	public GameObject root;

	public Button okButton;
	public Button cancelButton;

	public MainMenu mainMenu;


	private void OnOk()
	{
		PlayerPrefs.DeleteAll ();
		mainMenu.root.SetActive (false);
		root.SetActive (false);
		GameManager.targetDoorId = "level1door1";
		Application.LoadLevel ("level1");

	}


	private void OnCancel()
	{
		root.SetActive (false);
	}


	private void Awake()
	{
		cancelButton.onClick.AddListener (OnCancel);
		okButton.onClick.AddListener (OnOk);
	}
}
