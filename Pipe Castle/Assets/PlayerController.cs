using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Michael Altair 
 *  This class controls the player character's movement
 */

public class PlayerController : MonoBehaviour {

    private bool grounded;

    public float moveSpeed;
    public float jumpPower = 10;

    public Vector3 velocity;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            PlayerMove(input);
        }


        // Detecting if the player is midair
        if(gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            grounded = true;
        } else
        {
            grounded = false;
        }
    }

    public void PlayerMove(Vector2 input)
    {
        float targetVelocityX = input.x * moveSpeed;
        velocity.x = targetVelocityX;
        transform.Translate(velocity * Time.deltaTime);

        if(input.y > 0)
        {
            PlayerJump();
        }
    }

    public void PlayerJump()
    {
        //gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpPower);
        if (grounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x, jumpPower, 0), ForceMode2D.Impulse);
        }
    }

    // Damage Logic
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            Hurt();
        }
    }

    // Triggers when the player is injured
    public void Hurt()
    {
        Debug.Log("Hurt Player!");
    }
}
