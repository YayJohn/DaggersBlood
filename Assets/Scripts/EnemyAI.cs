using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	Vector2 playerPosition;
	public GameObject player;
	public EnemyRules enemyRules;
	public GameObject machete;
	public Animator enemyAnimator;
	bool timerEnabler = false;
	float timer = 1.5f;
	public bool enemyRotated = false;
	public bool enemyDead = false;

	// Update is called once per frame
	void Update () {
		if(enemyDead == false) {
			playerPosition = new Vector2(GameObject.Find("Player").transform.position.x, 0);
			transform.position = Vector3.MoveTowards(transform.position, playerPosition, 1f * Time.deltaTime);
		}
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
		if (enemyDead == false) {
			if (player.transform.position.x < transform.position.x && enemyRotated == false) {
				enemyAnimator.Play("EnemyRotating");
				enemyRotated = true;
			} else if (player.transform.position.x > transform.position.x && enemyRotated == true) {
				enemyAnimator.Play("EnemyRotatingReversed");
				enemyRotated = false;
			}
		}
	}
	void OnTriggerEnter2D (Collider2D collision) {
		if(collision.gameObject.name != "Machete") {
			if(enemyDead == false) {
				if(enemyRotated == false) {
					gameObject.GetComponentInChildren<Animator>().Play("EnemyAttack");
				} else {
					gameObject.GetComponentInChildren<Animator>().Play("EnemyAttackRotated");
				}
				timerEnabler = true;
			} else {
				machete.GetComponent<CapsuleCollider2D>().isTrigger = false;
			}
		}
    }
}