using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillingScript : MonoBehaviour {

      bool stunned = false;
      float stunnedTimer = 2f;
      int healthAddingPending = 0;
      public PlayerRules playerRules;
      public RegularEnemyAI regularEnemyAI;

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
            if (regularEnemyAI.enemyDead == false) {
                  if (regularEnemyAI.stunned == false) {
                        // if the player touches the enemy's sword decrease the players health by the enemy's attack power
                        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponentInChildren<CombatScript>().defending == false)
                              collision.gameObject.GetComponent<PlayerRules>().playerHealth -= 1;
                        else if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponentInChildren<CombatScript>().defending) {
                              if (gameObject.GetComponentInParent<RegularEnemyAI>().vulnerable) {
                                    if (healthAddingPending < 4)
                                          healthAddingPending += 1;
                                    if (healthAddingPending == 4) {
                                          playerRules.playerHealth += 1;
                                          healthAddingPending = 0;
                                          stunned = true;
                                          //gameObject.GetComponentInParent<Animator>().applyRootMotion = false;
                                          gameObject.GetComponentInParent<Animator>().Play("EnemyBlockedKnockback");
                                          playerRules.healthbarEnabler = true;
                                          playerRules.healthBar.SetActive(true);
                                    }
                              }
                        }
                  }
            }
      }
}
