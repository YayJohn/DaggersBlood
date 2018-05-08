using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertSystem : MonoBehaviour {

	public RegularEnemyAI regularEnemyAI;
	bool stopBeingAlerted = true;
	float stopBeingAlertedTimer = 12.5f;
	int suspecting = 0;
	float suspectingTimer = 3.25f;
	int facingLeftOrRight = 1;

	void Update() {
		if (suspecting == 1) {
			//Show a question mark here
			if (suspectingTimer > 0)
				suspectingTimer -= Time.deltaTime;
			else {
				regularEnemyAI.alerted = true;
				//show a exlmanation mark here
				suspecting = 0;
			}
		} else if (suspecting == 2) {
			//Show a question mark here
			if (suspectingTimer < 12.5f)
				suspectingTimer += Time.deltaTime;
			else
				suspecting = 0;
		}
		if (suspecting == 0)
			//remove question mark here

		if (stopBeingAlerted) {
			if (stopBeingAlertedTimer > 0)
				stopBeingAlertedTimer -= Time.deltaTime;
			else {
				regularEnemyAI.alerted = false;
				//remove exlamation mark here
				stopBeingAlertedTimer = 12.5f;
				stopBeingAlerted = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		suspectingTimer = 3.25f;
		suspecting = 1;
		stopBeingAlerted = false;
	}

	void OnTriggerExit2D(Collider2D collision) {
		suspectingTimer = 6.5f;
		suspecting = 2;
		stopBeingAlerted = true;
	}
}
