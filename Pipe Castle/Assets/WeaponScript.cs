using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Damage Logic
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hitbox")
        {
            Debug.Log("HB!");
            // This triggers any functions in the other gameobject called hurt
            other.gameObject.SendMessageUpwards("Hurt");
        }
    }
}
