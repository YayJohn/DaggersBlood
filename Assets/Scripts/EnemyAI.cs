using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	Vector2 playerPosition;
	public GameObject player;
	bool timerEnabler = false;
	float timer = 1.5f;

	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<EnemyRules>().enemyDead == false) {
			playerPosition = new Vector2(GameObject.Find("Player").transform.position.x, 0);
			transform.position = Vector3.MoveTowards(transform.position, playerPosition, 1f * Time.deltaTime);
		}
		if (timerEnabler == true) {
			if(timer > 0f) {
				timer -= Time.deltaTime;
			} else {
				Debug.Log("Timer Done");
				GameObject.Find("Machete").GetComponent<CapsuleCollider2D>().enabled = false;
				GameObject.Find("Machete").GetComponent<CapsuleCollider2D>().enabled = true;
				timerEnabler = false;
				timer = 1.5f;
			}
		}
		if (player.transform != null) {
			transform.LookAt(player.transform);
		}
	}
	void OnTriggerEnter2D () {
            gameObject.GetComponentInChildren<Animator>().Play("EnemyAttack");
			timerEnabler = true;
    }
}
