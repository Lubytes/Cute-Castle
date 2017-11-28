using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehaviour : MonoBehaviour {

    public float horizontalSpeed;
    public float verticalSpeed;

    private Vector2 tempPosition;

	// Use this for initialization
	void Start () {
        tempPosition = transform.position;
        horizontalSpeed = 2;
        verticalSpeed = 2;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //we will only want to use horizontalSpeed to follow the player or pace back and forth (not currently planned)
        //tempPosition.x += horizontalSpeed;
 
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed);
        transform.position = tempPosition;
    }

    public void Hurt()
    {
        if (gameObject.GetComponent<Rigidbody2D>() != null)
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
        }
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        gameObject.SendMessage("Death");

    }
}
