using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicMixer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("music", 1) == 0) 
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Stop();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
