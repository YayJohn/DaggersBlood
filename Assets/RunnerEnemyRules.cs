using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemyRules : MonoBehaviour {

	[HideInInspector]
    public int enemyHealth = 1;
	bool deathAnimationInitiated = false;

    void Update() {
		// if the enemy's health is less or equal to 0 and he still didnt do this if, then say that he's dead and play his death animation 
        if(enemyHealth <= 0 && deathAnimationInitiated == false) {
            gameObject.GetComponent<RunnerEnemyAI>().enemyDead = true;
			gameObject.GetComponent<Animator>().Play("EnemyDeath");
			deathAnimationInitiated = true;
        }
    }
}