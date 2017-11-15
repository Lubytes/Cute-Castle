using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBehaviour : MonoBehaviour
{

    public float horizontalSpeed;
    public float verticalSpeed;
    private GameObject player;

    private Vector2 tempPosition;

    // Use this for initialization
    void Start() {
        tempPosition = transform.position;
        horizontalSpeed = 2;
        verticalSpeed = 2;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (player.transform.position.x < this.transform.position.x) {
            tempPosition.x -= horizontalSpeed;
        }
        else if (player.transform.position.x > this.transform.position.x) {
            tempPosition.x += horizontalSpeed;
        }

        if (player.transform.position.y < this.transform.position.y) {
            tempPosition.y -= verticalSpeed;
        }
        else if (player.transform.position.y > this.transform.position.y) {
            tempPosition.y += verticalSpeed;
        }

        transform.position = tempPosition;
    }

}
