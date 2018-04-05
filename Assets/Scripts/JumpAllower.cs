using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAllower : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter2D(Collision2D collision) {
		// each time the player hits the ground make him able to double jump again
		if (collision.gameObject.tag == "Player") {
			collision.gameObject.GetComponent<PlayerMovement>().jumpEnabler = 2;
		}
	}
}
