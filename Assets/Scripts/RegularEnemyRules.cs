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

    void Update() {
		// shows a number of hearts corresponding to the enemy's health
        switch(enemyHealth) {
			case 2:
				FullHearts.SetActive(true);
				FullHeart3.SetActive(false);
				EmptyHearts.SetActive(true);
				break;
			case 1:
				FullHeart2.SetActive(false);
				break;
			case 0:
				FullHeart3.SetActive(true);
				FullHeart2.SetActive(true);
				FullHeart1.SetActive(true);
				FullHearts.SetActive(false);
				break;				
		}
		// if the enemy's health is less or equal to 0 and he still didnt do this if, then say that he's dead and play his death animation 
        if(enemyHealth <= 0 && deathAnimationInitiated == false) {
            gameObject.GetComponent<RegularEnemyAI>().enemyDead = true;
			if (gameObject.GetComponent<RegularEnemyAI>().enemyRotated == false) {
				gameObject.GetComponent<Animator>().Play("EnemyDeath");
			} else {
				gameObject.GetComponent<Animator>().Play("EnemyDeathRotated");
			}
			deathAnimationInitiated = true;
        }
    }
}