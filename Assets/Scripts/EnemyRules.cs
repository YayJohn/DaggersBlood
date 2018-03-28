using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRules : MonoBehaviour {

    public int enemyHealth = 3;
    public int enemyAttack = 1;
    public bool enemyDead = false;
    public GameObject FullHearts;
	public GameObject FullHeart1;
	public GameObject FullHeart2;
	public GameObject FullHeart3;
	public GameObject EmptyHearts;

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
        if(enemyHealth <= 0) {
            enemyDead = true;
            gameObject.GetComponent<Animator>().Play("EnemyDeath");
        }
    }
}