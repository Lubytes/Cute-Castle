using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinGame : MonoBehaviour {

	public InputField input;


		public void GetInput ()
		{

		string gameName = input.text;

		// this is where you will use the game name variable;
		Debug.Log (gameName);

		}
		

}
