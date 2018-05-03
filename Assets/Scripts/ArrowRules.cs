using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRules : MonoBehaviour {

	bool hittedSomething = false;
	float hittedSomethingTimer = 25f;
	float notHitSomethingTimer = 7.5f;

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "RunnerEnemy")
			collision.gameObject.GetComponent<RunnerEnemyRules>().enemyHealth -= 1;
		else if(collision.gameObject.tag == "RegularEnemy")
			collision.gameObject.GetComponent<RegularEnemyRules>().enemyHealth -= 1;
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
		transform.parent = collision.gameObject.transform;
		gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
		hittedSomething = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.name != "PlayersArrow") {
			if (hittedSomething == false) {
				if (notHitSomethingTimer > 0)
					notHitSomethingTimer -= Time.deltaTime;
				else
					Destroy(gameObject);
			} else if (hittedSomething == true) {
				if (hittedSomethingTimer > 0)
					hittedSomethingTimer -= Time.deltaTime;
				else
					Destroy(gameObject);
			}
		}
	}
}
