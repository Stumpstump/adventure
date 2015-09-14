using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour 
{

	public float speed = 10f;
	public float jumpForce = 10f;

	private Rigidbody2D rigidBody;
	private bool grounded;


	public Rigidbody2D RigidBody
	{
		get{ return rigidBody; }
	}


	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground") 
		{
			grounded = true;
		}
	}


	private void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground") 
		{
			grounded = true;
		}
	}


	private void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground") 
		{
			grounded = false;
		}
	}

	
	private void FixedUpdate () 
	{
		rigidBody.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, rigidBody.velocity.y);

		if(grounded && Input.GetAxis ("Vertical") > 0f)
		{
			rigidBody.velocity = new Vector2 (rigidBody.velocity.x, jumpForce);
		}
	}


	private void Awake()
	{
		rigidBody = this.GetComponent<Rigidbody2D> ();
	}
}
