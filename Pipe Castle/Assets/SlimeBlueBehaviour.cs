using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBlueBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (rb.velocity.y == 0) {
            rb.AddForce(new Vector3(0, 4, 0), ForceMode2D.Impulse);
        }
    }
}
