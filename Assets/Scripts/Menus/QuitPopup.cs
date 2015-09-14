using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuitPopup : MonoBehaviour 
{
	public GameObject root;

	public Button okButton;
	public Button cancelButton;
	
	
	
	private void OnOk()
	{
		Application.Quit ();
	}


	private void OnCancel()
	{
		root.SetActive (false);
	}
	
	
	private void Awake()
	{
		okButton.onClick.AddListener (OnOk);
		cancelButton.onClick.AddListener (OnCancel);
	}
}
