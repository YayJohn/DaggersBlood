using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEnemyAI : MonoBehaviour {

	Vector2 playerPosition;
	public GameObject player;
	public RegularEnemyRules enemyRules;
	public GameObject machete;
	public Animator enemyAnimator;
	bool timerEnabler = false;
	float timer = 1.5f;
	[HideInInspector]
	public bool enemyRotated = false;
	[HideInInspector]
	public bool enemyDead = false;
	Vector3 facingLeftScale;
	Vector3 facingRightScale;

	void Start() {
		facingRightScale = transform.localScale;
		facingLeftScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}
	void OnTriggerEnter2D (Collider2D collision) {
		// if the enemy trigger touched something that isnt his machete and he isnt dead attack if he is dead make the sword non lethal
		if(collision.gameObject.name != "Machete") {
			if(enemyDead == false) {
				gameObject.GetComponentInChildren<Animator>().Play("EnemyAttack");
				timerEnabler = true;
			} else {
				machete.GetComponent<CapsuleCollider2D>().isTrigger = false;
			}
		}
    }
	// Update is called once per frame
	void Update () {
		// if the enemy isnt dead follow the player
		if(enemyDead == false) {
			playerPosition = new Vector2(GameObject.Find("Player").transform.position.x, 0);
			transform.position = Vector3.MoveTowards(transform.position, playerPosition, 1f * Time.deltaTime);
		}
		// if the player sticks to the enemy he will get damaged once and thats it, this fixes that
		if (timerEnabler == true) {
			if(timer > 0f) {
				timer -= Time.deltaTime;
			} else {
				machete.GetComponent<CapsuleCollider2D>().enabled = false;
				machete.GetComponent<CapsuleCollider2D>().enabled = true;
				timerEnabler = false;
				timer = 1.5f;
			}
		}
		// if the enemy isnt dead it rotates to the player
		if (enemyDead == false) {
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