using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour {
	
    float timer = 0.75f;
    bool timerStarter = false;
    public bool defending = false;
    public bool dodging = false;
    public GameObject coreArrow;
    GameObject arrow;
    public Camera camera;
    public float arrowSpeed = 100000f;
    public PlayerRules playerRules;
    float facingLeftOrRight = 1f;
    public GameObject bow;
    public GameObject sword;
    Vector3 bowPosition;
    float chargeDuration = 0f;
    float chargeDurationNeeded = 2f;
    bool chargingBow = false;
    bool firstTime = true;
    float chargeDurationToOne;

	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            sword.GetComponent<SpriteRenderer>().enabled = true;
            bow.GetComponent<SpriteRenderer>().enabled = false;
            // makes the sword lethal only when you press the attack button
            sword.GetComponent<CapsuleCollider2D>().enabled = true;
            sword.GetComponent<Animator>().Play("LightAttackMedivalSword");
            timerStarter = true;
            playerRules.healthbarEnabler = true;
            playerRules.healthBar.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && dodging == false) {
            gameObject.GetComponent<Animator>().Play("PlayerDodging");
            transform.position = new Vector2(transform.position.x + Input.GetAxisRaw("Horizontal") * 5f, transform.position.y);
            dodging = true;
        }

        //starts an 75 milisecond timer if its requested to be started
        if (timerStarter == true) {
            if (timer > 0)
                timer -= Time.deltaTime;
            else {
                // makes the sword not lethal when the animation is finished
                sword.GetComponent<CapsuleCollider2D>().enabled = false;
                timerStarter = false;
                timer = 0.75f;
            }
        }
        if (Input.GetButton("Fire2") && playerRules.secondaryWeapon == "SwordDefence") {
            sword.GetComponent<Animator>().SetBool("defending", true);
            defending = true;
            sword.GetComponent<Animator>().Play("SwordDefence");
        } else if (Input.GetButton("Fire2") == false) {
            sword.GetComponent<Animator>().SetBool("defending", false);
            defending = false;
        } else if (Input.GetButton("Fire2") && playerRules.secondaryWeapon == "Bow") {
            Debug.Log("Key PRessed");
            sword.GetComponent<SpriteRenderer>().enabled = false;
            bow.GetComponent<SpriteRenderer>().enabled = true;
                //Play Charging Animation
                chargeDuration += Time.deltaTime;
                if (chargeDuration >= 6f) {
                    //Play an animation of the player's hand shaking here
                }
                else if (chargeDuration >= 8.5f) {
                    //Disable Player Charging Animation Here
                    chargeDuration = 0f;
                }
        } 
        if (Input.GetButton("Fire2") == false && chargeDuration > 0 && playerRules.secondaryWeapon == "Bow") {
            Debug.Log("Released Key");
            if (transform.localScale == playerRules.facingLeftScale) {
                facingLeftOrRight = -1f;
                bowPosition = new Vector3(-1.4f, 0f, 0f);
            } else {
                facingLeftOrRight = 1f;
                bowPosition = new Vector3(2.45f, 0f, 0f);
            }
            //2.45, 1.40, 0
            arrow = (Instantiate(coreArrow, gameObject.transform.position + bowPosition, Quaternion.Euler(0f, 0f, 90f * facingLeftOrRight)));
            arrow.GetComponent<CapsuleCollider2D>().enabled = true;
            arrow.GetComponent<MeshRenderer>().enabled = true;
            if (chargeDuration > chargeDurationNeeded)
                chargeDuration = chargeDurationNeeded;
            chargeDuration /= 2;
            //arrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(arrowSpeed * facingLeftOrRight * Time.deltaTime, 0f));
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowSpeed * chargeDuration * facingLeftOrRight * Time.deltaTime, 0f);
            chargeDuration = 0f;
        }
	}
    void OnTriggerEnter2D(Collider2D collision) {
        // if the sword collided with an enemy and not its attack trigger then lower his health by the player's attack power (currently 1)
        if (collision.gameObject.tag == "RegularEnemy") {
            if (collision != collision.gameObject.GetComponent<BoxCollider2D>())
                collision.gameObject.GetComponent<RegularEnemyRules>().enemyHealth -= 1;
        } else if (collision.gameObject.tag == "RunnerEnemy") {
            if (collision != collision.gameObject.GetComponent<BoxCollider2D>())
                collision.gameObject.GetComponent<RunnerEnemyRules>().enemyHealth -= 1;
        }
    }
}
