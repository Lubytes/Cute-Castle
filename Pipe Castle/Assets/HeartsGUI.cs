using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsGUI : MonoBehaviour {

    public Sprite heartEmpty, heartFull;
    public GameObject[] hearts;

    public int numHearts;

	// Use this for initialization
	void Start () {
        UpdateHearts();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Updates the display to show the number of hearts the player has
    void UpdateHearts()
    {

        hearts[0].GetComponent<SpriteRenderer>().sprite = heartEmpty;
        hearts[1].GetComponent<SpriteRenderer>().sprite = heartEmpty;
        hearts[2].GetComponent<SpriteRenderer>().sprite = heartEmpty;

        for (int i = numHearts- 1; i >= 0; i--)
        {
            hearts[i].GetComponent<SpriteRenderer>().sprite = heartFull;
        }
    }
}
