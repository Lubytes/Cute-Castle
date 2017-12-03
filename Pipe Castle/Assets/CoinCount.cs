using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CoinCount : NetworkBehaviour {

	public Sprite[] coinSprite;
	public GameObject[] gameObjects;
    [SyncVar]
	public int numCoins;

	// Use this for initialization
	void Start () {
        LoadCoins();
		UpdateCoins ();
    }

	public void UpdateCoins(){

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
        SaveCoins();
    }

    void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", numCoins);
        UpdateCoins();
    }

    void LoadCoins()
    {
        numCoins = PlayerPrefs.GetInt("Coins");
        UpdateCoins();
    }

    public void ResetCoins()
    {
        numCoins = 0;
        SaveCoins();
        UpdateCoins();
    }
}
