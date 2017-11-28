using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSpiderBehaviour : MonoBehaviour {

    public Rigidbody2D rb;
    private int walkCount = 0;
    private int walkDistance = 1;
    private bool direction = false; //false = left,  true = right

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (rb != null && rb.velocity.y == 0) {
            walkCount++;

            if (direction) {
                rb.AddForce(new Vector3(2, 4, 0), ForceMode2D.Impulse);
            }
            else {
                rb.AddForce(new Vector3(-2, 4, 0), ForceMode2D.Impulse);
            }

            if (walkCount > walkDistance){
                direction = !direction;
                walkCount = 0;
            }
        }

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
