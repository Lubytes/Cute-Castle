using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehaviour : MonoBehaviour {

    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;

    private Vector2 tempPosition;

	// Use this for initialization
	void Start () {
        tempPosition = transform.position;
        horizontalSpeed = 0.03F;
        verticalSpeed = 4;
        amplitude = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //tempPosition.x += horizontalSpeed;
            //we will want to use horizontalSpeed to follow the player or pace back and forth
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPosition;
    }

}
