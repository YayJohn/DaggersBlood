using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillingScript : MonoBehaviour {
      public PlayerRules playerRules;

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
                  Debug.Log("Player Hit");
                  playerRules.playerHealth -= 1;
            }
      }
}
