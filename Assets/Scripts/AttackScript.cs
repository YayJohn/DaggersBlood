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
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            GetComponent<Animator>().Play("LightAttackMedivalSword");
            timerStarter = true;
        }

        if (timerStarter == true) {
            if (timer > 0) {
                timer -= Time.deltaTime;
            } else {
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                timerStarter = false;
                timer = 0.75f;
            }
        }
	}
    void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Enemy" && collision != collision.gameObject.GetComponent<BoxCollider2D>()) {
            collision.gameObject.GetComponent<EnemyRules>().enemyHealth -= 1;
        }
    }
}
