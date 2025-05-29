using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    float chargeDurationNeeded = 1f;
    bool chargingBow = false;
    bool firstTime = true;
    float chargeDurationToOne;
    bool ableToShoot = true;
    int comboAttacks = 0;
    public GameObject enemy;
    float dontClipThroughEnemyWhenAttackingMax;
    bool enemyInAttackingRange;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision != null) {
            enemy = collision.gameObject;
            enemyInAttackingRange = true;
        }
        else
            enemyInAttackingRange = false;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            sword.GetComponent<SpriteRenderer>().enabled = true;
            bow.GetComponent<SpriteRenderer>().enabled = false;
            // makes the sword lethal only when you press the attack button
            sword.GetComponent<CapsuleCollider2D>().enabled = true;
            if (transform.localScale == playerRules.facingLeftScale) {
                facingLeftOrRight = -1f;
            } else {
                facingLeftOrRight = 1f;
            }
            switch(comboAttacks) {
                case 0:
                    sword.GetComponent<Animator>().Play("PlayerLightAttackComboStarter");
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + (2.5f * facingLeftOrRight), transform.position.y), 200f * 0.16f);
                    if (enemyInAttackingRange && enemy.transform.position.x < transform.position.x + 5f * facingLeftOrRight && enemy.transform.position.x > transform.position.x && enemy.transform.position.y < transform.position.y + 0.62f && enemy.transform.position.y > transform.position.y - 0.62f)
                        transform.position = new Vector2(enemy.transform.position.x + 1.247174f * facingLeftOrRight, transform.position.y);
                    else
                        transform.position = new Vector2(transform.position.x + 1 * facingLeftOrRight, transform.position.y);
                    break;

                default:
                    comboAttacks = 0;
                    break;
            }
            //comboAttacks += 1;
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
        } else if (Input.GetButton("Fire2") && playerRules.secondaryWeapon == "Bow" && ableToShoot) {
            sword.GetComponent<SpriteRenderer>().enabled = false;
            bow.GetComponent<SpriteRenderer>().enabled = true;
                bow.GetComponent<Animator>().Play("ChargingBow");
                chargeDuration += Time.deltaTime;
                if (chargeDuration >= 2.8f) {
                    bow.GetComponent<Animator>().Play("BowShaking");
                }
                if (chargeDuration >= 4f) {
                    chargeDuration = 0f;
                    ableToShoot = false;
                    bow.GetComponent<Animator>().Play("Idle");
                }
        } 
        if (Input.GetButton("Fire2") == false && playerRules.secondaryWeapon == "Bow") {
            if (chargeDuration == 0)
                ableToShoot = true;
            else {
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
                //arrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(arrowSpeed * facingLeftOrRight * Time.deltaTime, 0f));
                arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowSpeed * chargeDuration * facingLeftOrRight * Time.deltaTime, 0f);
                chargeDuration = 0f;
            }
        }
	}
}
