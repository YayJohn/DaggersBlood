using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collision) {
        // if the sword collided with an enemy and not its attack trigger then lower his health by the player's attack power (currently 1)
        if (collision.gameObject.tag == "RegularEnemy") {
            if (collision != collision.gameObject.GetComponent<BoxCollider2D>())
                collision.gameObject.GetComponent<RegularEnemyRules>().enemyHealth -= 1;
        } else if (collision.gameObject.tag == "RunnerEnemy") {
            if (collision != collision.gameObject.GetComponent<BoxCollider2D>())
                collision.gameObject.GetComponent<RunnerEnemyRules>().enemyHealth -= 1;
        }
    }
}
