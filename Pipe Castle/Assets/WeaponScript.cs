using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    private MusicMixer mixer;

    // Damage Logic
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hitbox")
        {
            mixer = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicMixer>();
            mixer.PlaySquish();
            // This triggers any functions in the other gameobject called hurt
            other.gameObject.SendMessageUpwards("Hurt");
        }
    }
}
