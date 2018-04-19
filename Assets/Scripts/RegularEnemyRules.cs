using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEnemyRules : MonoBehaviour {

	[HideInInspector]
    public int enemyHealth = 3;
	[HideInInspector]
    public int enemyAttack = 1;
    public GameObject FullHearts;
	public GameObject FullHeart1;
	public GameObject FullHeart2;
	public GameObject FullHeart3;
	public GameObject EmptyHearts;
	bool deathAnimationInitiated = false;
	bool firstTime = true;

    void Update() {
		// shows a number of hearts corresponding to the enemy's health
        switch(enemyHealth) {
			case 3:
				if (!firstTime)
					FullHearts.SetActive(true);
				FullHeart3.SetActive(true);
				FullHeart2.SetActive(true);
				FullHeart1.SetActive(true);
				EmptyHearts.SetActive(false);
				break;
			case 2:
				firstTime = false;
				FullHearts.SetActive(true);
				FullHeart3.SetActive(false);
				FullHeart2.SetActive(true);
				FullHeart1.SetActive(true);
				EmptyHearts.SetActive(true);
				break;
			case 1:
				FullHearts.SetActive(true);
				FullHeart3.SetActive(false);
				FullHeart2.SetActive(false);
				FullHeart1.SetActive(true);
				EmptyHearts.SetActive(true);
				break;
			case 0:
				FullHearts.SetActive(false);
				EmptyHearts.SetActive(true);
				break;				
		}
		// if the enemy's health is less or equal to 0 and he still didnt do this if, then say that he's dead and play his death animation 
        if(enemyHealth <= 0 && deathAnimationInitiated == false) {
            gameObject.GetComponent<RegularEnemyAI>().enemyDead = true;
			gameObject.GetComponent<Animator>().Play("EnemyDeath");
			deathAnimationInitiated = true;
        }
    }
}