using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemyAI : MonoBehaviour {

	Vector2 playerPosition;
	[HideInInspector]
	public bool enemyRotated = false;
	[HideInInspector]
	public bool enemyDead = false;

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
			collision.gameObject.GetComponent<PlayerRules>().playerHealth -= 1;
		}
	}
	// Update is called once per frame
	void Update () {
		// if the enemy isnt dead follow the player
		if(enemyDead == false) {
			playerPosition = new Vector2(GameObject.Find("Player").transform.position.x, 0);
			transform.position = Vector3.MoveTowards(transform.position, playerPosition, 10f * Time.deltaTime);
		}
	}
}