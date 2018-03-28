using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public int jumpEnabler;

    // Update is called once per frame
    void FixedUpdate () {
		if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
        }

        if (Input.GetKeyDown("space") && jumpEnabler >= 1)
        {
            rb.velocity = new Vector2(rb.velocity.x * Time.deltaTime, Input.GetAxisRaw("Jump") * 60f * speed * Time.deltaTime);
            jumpEnabler -= 1;
        }
    }
}
