using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinController : MonoBehaviour {

    AudioSource sound;

    // Use this for initialization
    void Start() {
        sound = GetComponent<AudioSource>();
	}
}
