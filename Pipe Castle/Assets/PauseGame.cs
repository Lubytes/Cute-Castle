using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseGame : MonoBehaviour {
	
	public Transform canvas;
	public Scene scene;

	// Update is called once per frame
	void Update () {
		//using escape key for now until toggle is put in game screen.
		if(Input.GetKeyDown(KeyCode.Escape)){
			Pause ();
		}
	}

	public void Pause () {
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
			// pause time
			Time.timeScale = 0;

		} 
		else {
			canvas.gameObject.SetActive (false);
			// set time back to normal
			Time.timeScale = 1;
		}
	}

	public void Restart(){
		
		scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
		Pause ();

	}

//	public void Save(){
//	
//		scene = SceneManager.GetActiveScene ();
//
//
//	}
		
}

