using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRules : MonoBehaviour {

	public int playerHealth = 3;
    public int playerAttack = 1;
	public GameObject FullHearts;
	public GameObject FullHeart1;
	public GameObject FullHeart2;
	public GameObject FullHeart3;
	public GameObject EmptyHearts;
	public GameObject EndGameScreen;
	
	void Update() {
		switch(playerHealth) {
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
		if (playerHealth <= 0) {
			EndGameScreen.SetActive(true);
		}
	}
}
