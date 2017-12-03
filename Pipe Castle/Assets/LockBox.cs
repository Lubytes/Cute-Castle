using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBox : MonoBehaviour {

    public string colour;
    public MusicMixer mixer;

    void Start()
    {
        mixer = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicMixer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController playerScript = other.GetComponent<PlayerController>();
            if (playerScript.GetInHandsColour().Equals(colour))
            {
                mixer.PlayReveal();
                playerScript.DropObject(gameObject);
            }
        }
    }
}
