using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {


	public Toggle musicToggle;
	public Toggle sfxToggle;

    public void Start()
    {
        musicToggle.isOn = PlayerPrefs.GetInt("music", 1) == 1;
        sfxToggle.isOn = PlayerPrefs.GetInt("sfx", 1) == 1;
    }

    public void loadMusic(){
	
		if (musicToggle.isOn) {
            PlayerPrefs.SetInt("music", 1);
		} else if (!musicToggle.isOn) {
            PlayerPrefs.SetInt("music", 0);
		}
	}

	public void loadSfx(){
		if (sfxToggle.isOn) {
            PlayerPrefs.SetInt("sfx", 1);
		} else if (!sfxToggle.isOn) {
            PlayerPrefs.SetInt("sfx", 0);
		}
	}

}
