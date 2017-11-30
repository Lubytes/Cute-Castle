using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class EndlevelDoor : NetworkBehaviour {

    public string destination;

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
            CmdNextLevel();
        }
    }

    [Command]
    void CmdNextLevel()
    {
			NetworkManager.singleton.ServerChangeScene (destination);
    }
}
