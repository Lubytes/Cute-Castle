using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MainScreenController : MonoBehaviour {

	public Transform canvas;

	public void LoadByName(string sceneName){
		SceneManager.LoadScene (sceneName);
	}

	public void NewGame(){
		NetworkManager.singleton.StartHost ();
        PlayerPrefs.SetInt("Coins", 0);
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
