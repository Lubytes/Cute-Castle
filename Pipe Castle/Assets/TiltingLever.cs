using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltingLever : MonoBehaviour {

    public SpriteRenderer ownerDisplay;
    public Sprite player1, player2;

    private bool claimed;
    private Quaternion localRotation; // 
    public float speed;
    // Use this for initialization
    void Start () {
        localRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {

        if(claimed)
        {
            // first update the current rotation angles with input from acceleration axis
            localRotation.y += Input.acceleration.x * speed;
            localRotation.x += Input.acceleration.y * speed;

            // then rotate this object accordingly to the new angle
            transform.rotation = localRotation;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(other.GetComponent<PlayerController>().localPlayer)
            {
                claimed = true;
                ownerDisplay.sprite = player1;
            } else
            {
                ownerDisplay.sprite = player2;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<PlayerController>().localPlayer)
            {
                ownerDisplay.sprite = null;
                claimed = false;
            }
        }
    }
}
