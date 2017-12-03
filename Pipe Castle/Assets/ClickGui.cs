using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickGui : MonoBehaviour {


	public Canvas secondCanvas;

	// // Use this for initialization
	// void Start () {
		
	// }


	public void PopupWindow() {

		if(secondCanvas.gameObject.activeInHierarchy == false){
		
			secondCanvas.gameObject.SetActive (true);

		}
		else {
			secondCanvas.gameObject.SetActive (false);

		}

	}

	// // Update is called once per frame
	// void Update () {
		
	// }

	
}
