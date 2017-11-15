using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinCount : MonoBehaviour {

	public Sprite[] coinSprite;
	public GameObject[] gameObjects;
	public int numCoins;

	// Use this for initialization
	void Start () {

		IncrementCoin ();
		UpdateCoins ();

}
	void UpdateCoins(){
		
		var digits = new List<int>();
		while (numCoins > 0)
		{
			digits.Add(numCoins % 10);
			numCoins /= 10;
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
