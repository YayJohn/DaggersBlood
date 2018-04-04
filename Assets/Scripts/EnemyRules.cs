using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRules : MonoBehaviour {

    public int enemyHealth = 3;
    public int enemyAttack = 1;
    public GameObject FullHearts;
	public GameObject FullHeart1;
	public GameObject FullHeart2;
	public GameObject FullHeart3;
	public GameObject EmptyHearts;
	bool deathAnimationInitiated = false;

    void Update() {
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
        if(enemyHealth <= 0 && deathAnimationInitiated == false) {
            gameObject.GetComponent<EnemyAI>().enemyDead = true;
			if (gameObject.GetComponent<EnemyAI>().enemyRotated == false) {
				gameObject.GetComponent<Animator>().Play("EnemyDeath");
			} else {
				gameObject.GetComponent<Animator>().Play("EnemyDeathRotated");
			}
			gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
			deathAnimationInitiated = true;
        }
    }
}