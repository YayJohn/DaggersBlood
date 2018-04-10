using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {
	
    float timer = 0.75f;
    bool timerStarter = false;

	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            // makes the sword lethal only when you press the attack button
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            GetComponent<Animator>().Play("LightAttackMedivalSword");
            timerStarter = true;
            GetComponentInParent<PlayerRules>().timerStarter = true;
            GetComponentInParent<PlayerRules>().healthBar.SetActive(true);
        }

        //starts an 75 milisecond timer if its requested to be started
        if (timerStarter == true) {
            if (timer > 0) {
                timer -= Time.deltaTime;
            } else {
                // makes the sword not lethal when the animation is finished
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                timerStarter = false;
                timer = 0.75f;
            }
        }
	}
    void OnTriggerEnter2D(Collider2D collision) {
        // if the sword collided with an enemy and not its attack trigger then lower his health by the player's attack power (currently 1)
		if (collision.gameObject.tag == "RegularEnemy" && collision != collision.gameObject.GetComponent<BoxCollider2D>()) {
            collision.gameObject.GetComponent<RegularEnemyRules>().enemyHealth -= 1;
        } else if (collision.gameObject.tag == "RunnerEnemy" && collision != collision.gameObject.GetComponent<BoxCollider2D>()) {
            collision.gameObject.GetComponent<RunnerEnemyRules>().enemyHealth -= 1;
        }
    }
}
