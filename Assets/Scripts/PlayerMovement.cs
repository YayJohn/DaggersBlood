using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    [HideInInspector]
    public int jumpEnabler = 0;
    //Fixes inverse movement when the player is flipped
    int playerRotatedMovementFixer = 1;
    bool jumpInitiatorEnabled = false;

    void Update() {
        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
            //move him right or left
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * playerRotatedMovementFixer * speed * Time.deltaTime, 0f));
        }
        // make the character jump if he didnt have already jumped twice before hitting the ground
        if (Input.GetKeyDown("space") && jumpEnabler >= 1) {
            jumpInitiatorEnabled = true;
            jumpEnabler -= 1;
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (jumpInitiatorEnabled == true) {
            rb.velocity = new Vector2(rb.velocity.x * Time.deltaTime, Input.GetAxisRaw("Jump") * 60f * speed * Time.deltaTime);
            jumpInitiatorEnabled = false;
        }
    }
}
