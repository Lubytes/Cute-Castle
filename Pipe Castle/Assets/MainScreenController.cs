using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenController : MonoBehaviour {

	public Transform canvas;

	public void LoadByName(string sceneName){
	
		SceneManager.LoadScene (sceneName);
		Debug.Log ("Go to scene" + sceneName);
		
	}

	public void QuitGame(){
	
		Application.Quit ();
		Debug.Log ("Game quit");
	}
		
	public void JoinGame(){
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
		}
	}
}
