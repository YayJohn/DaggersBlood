using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAllower : MonoBehaviour {

	public PlayerMovement playerMovement;

	// Use this for initialization
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			playerMovement.GetComponent<PlayerMovement>().jumpEnabler = 2;
			Debug.Log("Standing on ground");
		}
	}
}
