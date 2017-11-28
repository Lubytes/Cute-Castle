using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBehaviour : MonoBehaviour {

    public Rigidbody2D rb;
    private int walkCount = 0;
    private int walkDistance = 100;
    private bool direction = false; //false = left,  true = right

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (rb != null && rb.velocity.y == 0) {
            walkCount += 1;

            if (direction) {
                rb.AddForce(new Vector3(0.1F, 0, 0), ForceMode2D.Impulse);
            }
            else {
                rb.AddForce(new Vector3(-0.1F, 0, 0), ForceMode2D.Impulse);
            }

            if (walkCount > walkDistance) {
                direction = !direction;
                walkCount = 0;
            }
        }

    }

    public void Hurt()
    {
        if(gameObject.GetComponent<Rigidbody2D>() != null)
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
        }
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        gameObject.SendMessage("Death");

    }
}
