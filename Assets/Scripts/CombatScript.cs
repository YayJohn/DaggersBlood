using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour {
	
    float timer = 0.75f;
    bool timerStarter = false;
    public bool defending = false;
    public bool dodging = false;
    public GameObject player;
    public GameObject arrow;
    public Camera camera;
    public float arrowSpeed = 10f;

	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            // makes the sword lethal only when you press the attack button
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            GetComponent<Animator>().Play("LightAttackMedivalSword");
            timerStarter = true;
            gameObject.GetComponentInParent<PlayerRules>().timerStarter = true;
            gameObject.GetComponentInParent<PlayerRules>().healthBar.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && dodging == false) {
            player.GetComponent<Animator>().Play("PlayerDodging");
            player.transform.position = new Vector2(player.transform.position.x + Input.GetAxisRaw("Horizontal") * 5f, player.transform.position.y);
            dodging = true;
        }

        //starts an 75 milisecond timer if its requested to be started
        if (timerStarter == true) {
            if (timer > 0)
                timer -= Time.deltaTime;
            else {
                // makes the sword not lethal when the animation is finished
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                timerStarter = false;
                timer = 0.75f;
            }
        }
        if (Input.GetButton("Fire2") && gameObject.GetComponentInParent<PlayerRules>().secondaryWeapon == "SwordDefence") {
            gameObject.GetComponent<Animator>().SetBool("defending", true);
            defending = true;
            gameObject.GetComponent<Animator>().Play("SwordDefence");
            if (Input.GetButton("Fire2") == false) {
                gameObject.GetComponent<Animator>().SetBool("defending", false);
                defending = false;
            }
        } else if(Input.GetButtonDown("Fire2") && gameObject.GetComponentInParent<PlayerRules>().secondaryWeapon == "Bow") {
            arrow.GetComponent<MeshRenderer>().enabled = true;
            if (transform.parent.transform.localScale == transform.parent.GetComponent<PlayerRules>().facingLeftScale)
                arrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(-arrowSpeed * Time.deltaTime, 0f));
            else {
                arrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(arrowSpeed * Time.deltaTime, 0f));
            }
        }
	}
    void OnTriggerEnter2D(Collider2D collision) {
        // if the sword collided with an enemy and not its attack trigger then lower his health by the player's attack power (currently 1)
        if (collision.gameObject.name == "RegularEnemy") {
            if (collision != collision.gameObject.GetComponent<BoxCollider2D>()) {
                collision.gameObject.GetComponent<RegularEnemyRules>().enemyHealth -= 1;
            } else if (collision != collision.gameObject.GetComponent<BoxCollider2D>()) {
                collision.gameObject.GetComponent<RegularEnemyRules>().enemyHealth -= 1;
            }
        } else if (collision.gameObject.name == "RunnerEnemy") {
            if (collision != collision.gameObject.GetComponent<BoxCollider2D>()) {
                collision.gameObject.GetComponent<RunnerEnemyRules>().enemyHealth -= 1;
            } else if (collision != collision.gameObject.GetComponent<BoxCollider2D>()) {
                collision.gameObject.GetComponent<RunnerEnemyRules>().enemyHealth -= 1;
            }
        }
    }
}
