using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinCount : MonoBehaviour {

	public Sprite[] coinSprite;
	public GameObject[] gameObjects;
	public int numCoins;

	// Use this for initialization
	void Start () {

		UpdateCoins ();

    }
	void UpdateCoins(){

        int numCoinsRecorded = numCoins;
		var digits = new List<int>();
		while (numCoinsRecorded > 0)
		{
			digits.Add(numCoinsRecorded % 10);
            numCoinsRecorded /= 10;
		}

		digits.Reverse();

		int n = digits.Count;

		for(int i = 0; i<n; i++){
			gameObjects [i].GetComponent<SpriteRenderer> ().sprite = coinSprite [digits[i]];
		}	

    }
	public void IncrementCoin(){
		numCoins++;
		UpdateCoins ();
		
    }

}
