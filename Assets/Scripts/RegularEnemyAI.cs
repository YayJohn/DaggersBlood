using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEnemyAI : MonoBehaviour {

	Vector2 playerPosition;
	public GameObject player;
	bool timerEnabler = false;
	float timer = 1.667f;
	[HideInInspector]
	public bool enemyRotated = false;
	[HideInInspector]
	public bool enemyDead = false;
	Vector3 facingLeftScale;
	Vector3 facingRightScale;
	public bool vulnerable = false;
	float vulnerableTimer = 0.25f;
	bool vulnerablePreparerStarter = false;
	float vulnerablePreparerTimer = 0.269946011f;
	public bool stunned = false;

	void Start() {
		facingRightScale = transform.localScale;
		facingLeftScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}
	void OnTriggerEnter2D (Collider2D collision) {
		// if the enemy trigger touched something that isnt his machete and he isnt dead attack if he is dead make the sword non lethal
		if(enemyDead == false || stunned == false) {
			gameObject.GetComponentInChildren<Animator>().Play("EnemyAttack");
			vulnerablePreparerStarter = true;
			timerEnabler = true;
		} else {
			gameObject.GetComponentInChildren<CapsuleCollider2D>().isTrigger = false;
		}
    }
	// Update is called once per frame
	void Update () {
		// if the enemy isnt dead follow the player
		if(enemyDead == false || stunned == false) {
			playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
			transform.position = Vector3.MoveTowards(transform.position, playerPosition, 1f * Time.deltaTime);
		}
		if (vulnerablePreparerStarter) {
			if(vulnerablePreparerTimer > 0) {
				vulnerablePreparerTimer -= Time.deltaTime;
			} else {
				vulnerable = true;
				vulnerablePreparerTimer = 0.269946011f;
				vulnerablePreparerStarter = false;
			}
		}
		if (vulnerable) {
			if (vulnerableTimer > 0) {
				vulnerableTimer -= Time.deltaTime;
			} else {
				vulnerableTimer = 0.25f;
				vulnerable = false;
			}
		}
		// if the player sticks to the enemy he will get damaged once and thats it, this fixes that
		if (timerEnabler == true) {
			if(timer > 0f) {
				timer -= Time.deltaTime;
			} else {
				gameObject.GetComponentInChildren<CapsuleCollider2D>().enabled = false;
				gameObject.GetComponentInChildren<CapsuleCollider2D>().enabled = true;
				timerEnabler = false;
				timer = 1.667f;
			}
		}
		// if the enemy isnt dead it rotates to the player
		if (enemyDead == false || stunned == false) {
			if (player.transform.position.x < transform.position.x && enemyRotated == false) {
				transform.localScale = facingLeftScale;
				enemyRotated = true;
			} else if (player.transform.position.x > transform.position.x && enemyRotated == true) {
				transform.localScale = facingRightScale;
				enemyRotated = false;
			}
		}
	}
}