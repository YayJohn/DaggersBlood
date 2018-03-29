using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	Vector2 playerPosition;
	public GameObject player;
	public EnemyRules enemyRules;
	bool timerEnabler = false;
	float timer = 1.5f;

	// Update is called once per frame
	void Update () {
		if(enemyRules.enemyDead == false) {
			playerPosition = new Vector2(GameObject.Find("Player").transform.position.x, 0);
			transform.position = Vector3.MoveTowards(transform.position, playerPosition, 1f * Time.deltaTime);
		}
		if (timerEnabler == true) {
			if(timer > 0f) {
				timer -= Time.deltaTime;
			} else {
				GameObject.Find("Machete").GetComponent<CapsuleCollider2D>().enabled = false;
				GameObject.Find("Machete").GetComponent<CapsuleCollider2D>().enabled = true;
				timerEnabler = false;
				timer = 1.5f;
			}
		}
		/*Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5f);*/
	}
	void OnTriggerEnter2D () {
		if(enemyRules.enemyDead == false) {
			gameObject.GetComponentInChildren<Animator>().Play("EnemyAttack");
			timerEnabler = true;
		} else {
			GameObject.Find("Machete").GetComponent<CapsuleCollider2D>().isTrigger = false;
		}
    }
}
