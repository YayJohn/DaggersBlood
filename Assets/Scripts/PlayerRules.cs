using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRules : MonoBehaviour {

	[HideInInspector]
	public int playerHealth = 3;
	[HideInInspector]
    public int playerAttack = 1;
	public GameObject FullHearts;
	public GameObject FullHeart1;
	public GameObject FullHeart2;
	public GameObject FullHeart3;
	public GameObject EmptyHearts;
	public GameObject EndGameScreen;
	Vector3 facingLeftScale;
	Vector3 facingRightScale;
	public Camera camera;
	
	void Start() {
		facingLeftScale = transform.localScale;
		facingRightScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}
	void Update() {
		// shows a number of hearts corresponding to the player's health
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
		// if the player is dead show the EndGameScreen (GAME OVER Screen)
		if (playerHealth <= 0) {
			EndGameScreen.SetActive(true);
		}
		Vector3 MousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        if (transform.position.x > MousePosition.x) {
			Debug.Log("Curosr on left");
			transform.localScale = facingLeftScale;
		} else if(transform.position.x < MousePosition.x) {
			Debug.Log("Curosr on right");
			transform.localScale = facingRightScale;
		}
	}
}
