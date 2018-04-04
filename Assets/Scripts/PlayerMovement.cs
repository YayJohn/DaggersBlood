using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public int jumpEnabler;
    //Fixes inverse movement when the player is flipped
    int playerRotatedMovementFixer = 1;

    // Update is called once per frame
    void FixedUpdate () {
		if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * playerRotatedMovementFixer * speed * Time.deltaTime, 0f));
            if(Input.GetAxisRaw("Horizontal") > 0.5f) {
                transform.eulerAngles = new Vector2(0f, 180f);
                playerRotatedMovementFixer = -1;
            } else if(Input.GetAxisRaw("Horizontal") < -0.5f) {
                transform.eulerAngles = new Vector2(0f, 0f);
                playerRotatedMovementFixer = 1;
            }
        }

        if (Input.GetKeyDown("space") && jumpEnabler >= 1)
        {
            rb.velocity = new Vector2(rb.velocity.x * Time.deltaTime, Input.GetAxisRaw("Jump") * 60f * speed * Time.deltaTime);
            jumpEnabler -= 1;
        }
    }
}
