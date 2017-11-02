using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Michael Altair 
 *  This class controls the player character's movement
 */

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    public Vector3 velocity;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = targetVelocityX;
        transform.Translate(velocity * Time.deltaTime);

    }
}
