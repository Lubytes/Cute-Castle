using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlevelDoor : MonoBehaviour {

    public string destination;

    private int numPlayersRemaining;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    int CountPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        return players.Length;
    }

    // Collision logic
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            NextLevelCheck();
        }
    }

    void NextLevelCheck()
    {
        if(CountPlayers() <= 1)
        {
            SceneManager.LoadScene(destination, LoadSceneMode.Single);
        }
    }
}
