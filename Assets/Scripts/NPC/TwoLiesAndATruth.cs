using UnityEngine;
using System.Collections;

public class TwoLiesAndATruth : MonoBehaviour 
{
	public InteractibleObject choice1;
	public InteractibleObject choice2;
	public InteractibleObject choice3;

	public bool solved = false;

	public Collectible key;
	public Collectible proof;
	

	private IEnumerator Solve()
	{
		float desiredTime = 2f;
		float elapsedTime = 0f;

		SpriteRenderer sprite1 = choice1.GetComponent<SpriteRenderer> ();
		SpriteRenderer sprite2 = choice2.GetComponent<SpriteRenderer> ();
		SpriteRenderer sprite3 = choice3.GetComponent<SpriteRenderer> ();

		if(key != null) key.gameObject.SetActive (true);
		if(proof != null) proof.gameObject.SetActive (true);

		while(elapsedTime < desiredTime)
		{
			sprite1.color = Color.Lerp(sprite1.color, Color.clear, elapsedTime/desiredTime);
			sprite2.color = Color.Lerp(sprite2.color, Color.clear, elapsedTime/desiredTime);
			sprite3.color = Color.Lerp(sprite3.color, Color.clear, elapsedTime/desiredTime);

			elapsedTime += Time.deltaTime;
			yield return null;
		}

		desiredTime = 1f;
		elapsedTime = 0f;
		while(elapsedTime < desiredTime)
		{
			sprite1.transform.position = Vector3.Lerp(sprite1.transform.position, new Vector3(0f, 100f, 0f), elapsedTime/desiredTime);
			sprite2.transform.position = Vector3.Lerp(sprite2.transform.position, new Vector3(0f, 100f, 0f), elapsedTime/desiredTime);
			sprite3.transform.position = Vector3.Lerp(sprite3.transform.position, new Vector3(0f, 100f, 0f), elapsedTime/desiredTime);
			
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		Destroy (sprite1);
		Destroy (sprite2);
		Destroy (sprite3);

		if(key != null) key.gameObject.SetActive (true);
		if(proof != null) proof.gameObject.SetActive (true);
	}


	private void Update () 
	{
		if(choice2.activated || choice3.activated)
		{
			Debug.Log("waka waka");
			Application.LoadLevel(Application.loadedLevel);
		}
		else if (choice1.activated && !solved)
		{
			solved = true;
			StartCoroutine(Solve());
		}
	}


	private void Awake()
	{
		if(!string.IsNullOrEmpty(PlayerPrefs.GetString ("level2puzzle1proof")))
		{
			StartCoroutine(Solve());
		}
	}
}
