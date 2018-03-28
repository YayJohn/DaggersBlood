using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingScript : MonoBehaviour {
      public EnemyRules enemyRules;

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log("Enemy Hit");
		if (collision.gameObject.tag == "Enemy") {
                  Debug.Log("Enemy Hit");
                  enemyRules.enemyHealth -= 1;
            }
      }
}
