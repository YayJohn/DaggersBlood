using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillingScript : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D collision) {
            // if the player touches the enemy's sword decrease the players health by the enemy's attack power
		if (collision.gameObject.tag == "Player") {
                  collision.gameObject.GetComponent<PlayerRules>().playerHealth -= 1;
            }
      }
}
