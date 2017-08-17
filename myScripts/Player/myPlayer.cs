using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	private void move()
	{
		Vector3 fDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
		fDirection.Normalize ();

		CharacterController myController = GetComponent<CharacterController> ();
		if (myController != null)
		{
			myController.Move (fDirection * 10.0f * Time.deltaTime);
		}
	}
}
