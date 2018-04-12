using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemyAI : MonoBehaviour {

	Vector2 playerPosition;
	[HideInInspector]
	public bool enemyDead = false;
	public float movementSpeed = 5f;
	bool timerStarter = false;
	float timer = 1.25f;
	public GameObject player;
	bool vulnerable = false;
	float vulnerableTimer = 0.5f;
	bool stunned = false;
	float stunnedTimer = 2f;

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player" && player.GetComponentInChildren<CombatScript>().defending == false && stunned == false) {
			player.GetComponent<PlayerRules>().stunned = true;
			collision.gameObject.GetComponent<PlayerRules>().playerHealth -= 1;
		} else if (collision.gameObject.tag == "Player" && player.GetComponentInChildren<CombatScript>().defending == true) {
			stunned = true;
			gameObject.GetComponent<Animator>().Play("Stunned");
		}
	}
	// Update is called once per frame
	void Update () {
		if (timerStarter == true && stunned == false) {
			if (timer > 0) {
				timer -= Time.deltaTime;
			} else {
				transform.position = new Vector2(player.transform.position.x - 2.5f, player.transform.position.y);
				timer = 1.25f;
				timerStarter = false;
				vulnerable = true;
			}
		// if the enemy isnt dead follow the player
		} else if (enemyDead == false && stunned == false) {
			playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
			transform.position = Vector3.MoveTowards(transform.position, playerPosition, 5f * Time.deltaTime);
		}
		if (vulnerable == true) {
			if (vulnerableTimer > 0) {
				vulnerableTimer -= Time.deltaTime;
			} else {
				vulnerableTimer = 0.5f;
				vulnerable = false;
			}
		}
		if (stunned == true) {
			if (stunnedTimer > 0) {
				stunnedTimer -= Time.deltaTime;
			} else {
				stunnedTimer = 2f;
				stunned = false;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
			timerStarter = true;
		}
	}
}