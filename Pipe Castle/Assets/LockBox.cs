using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBox : MonoBehaviour {

    public string colour;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController playerScript = other.GetComponent<PlayerController>();
            if (playerScript.GetInHandsColour().Equals(colour))
            {
                playerScript.DropObject(gameObject);
            }
        }
    }
}
