using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {


	public Toggle musicToggle;
	public Toggle sfxToggle;

	public void loadMusic(){
	
		if (musicToggle.isOn) {
			//music on
			Debug.Log ("yes");
		} else if (!musicToggle.isOn) {
			//music off
			Debug.Log ("no");
		}
	}

	public void loadSfx(){

		if (sfxToggle.isOn) {
			// sound effects on
			Debug.Log ("yes");
		} else if (!sfxToggle.isOn) {
			// sound effects off
			Debug.Log ("no");
		}
	}

}
