using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemyAI : MonoBehaviour {

	Vector2 playerPosition;
	[HideInInspector]
	public bool enemyRotated = false;
	[HideInInspector]
	public bool enemyDead = false;
	public float movementSpeed = 5f;
	bool attackMode = false;
	bool timerStarter = false;
	float timer = 1.25f;
	public GameObject player;

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			player.GetComponent<PlayerRules>().stunned = true;
			collision.gameObject.GetComponent<PlayerRules>().playerHealth -= 1;
		}
	}
	// Update is called once per frame
	void Update () {
		if (attackMode == true) {
			//Make it trigger an animation so the player will know the enemy is about to attack. right here!
			timerStarter = true;
		}
		playerPosition = new Vector2(GameObject.Find("Player").transform.position.x, 0);
		if (timerStarter == true) {
			if (timer > 0) {
				timer -= Time.deltaTime;
			} else {
				transform.position = Vector3.MoveTowards(transform.position, playerPosition, movementSpeed * Time.deltaTime);
				timer = 0.5f;
				timerStarter = false;
				attackMode = false;
			}
		} else {
			// if the enemy isnt dead follow the player
			if(enemyDead == false) {
				transform.position = Vector3.MoveTowards(transform.position, playerPosition, 5f * Time.deltaTime);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
			attackMode = true;
		}
	}
}