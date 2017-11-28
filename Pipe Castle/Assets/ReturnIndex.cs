using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnIndex : MonoBehaviour {

	void Start(){
	// blah blah
	
	}

	public void ReturnSceneName(){
	
		string y = SceneManager.GetActiveScene ().name;
		Debug.Log (y);

	}


}
