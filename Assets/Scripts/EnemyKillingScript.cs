using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillingScript : MonoBehaviour {

      bool stunned = false;
      float stunnedTimer = 2f;
      bool healthAddingPending = false;
      public GameObject player;

	void Update() {
            stunned = gameObject.GetComponentInParent<RegularEnemyAI>().stunned;
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
            // if the player touches the enemy's sword decrease the players health by the enemy's attack power
		if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponentInChildren<CombatScript>().defending == false) {
                  collision.gameObject.GetComponent<PlayerRules>().playerHealth -= 1;
            } else if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponentInChildren<CombatScript>().defending == true) {
                  if (gameObject.GetComponentInParent<RegularEnemyAI>().vulnerable) {
                        if (healthAddingPending) {
                              GameObject.Find("Player").GetComponent<PlayerRules>().playerHealth += 1;
                              healthAddingPending = false;
                              stunned = true;
                              player.GetComponent<PlayerRules>().timerStarter = true;
                              player.GetComponent<PlayerRules>().timer = 5f;
                              player.GetComponent<PlayerRules>().healthBar.SetActive(true);
                        } else {
                              healthAddingPending = true;
                        }
                        gameObject.GetComponentInParent<Animator>().Play("EnemyBlockedKnockback");
                  }
            }
      }
}
