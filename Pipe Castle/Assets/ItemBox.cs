using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ItemBox : NetworkBehaviour {

    public GameObject storedPowerUp;
    public Sprite emptyBlock;
    public BoxCollider2D trigger;


    private float spawnOffset = 0.35f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CmdSpawnPowerUp();
            gameObject.GetComponent<SpriteRenderer>().sprite = emptyBlock;
            trigger.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Power-Up" || other.gameObject.tag == "Health" || other.gameObject.tag == "Coin")
        {
            other.GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    [Command]
    void CmdSpawnPowerUp()
    {
        GameObject spawnedPowerUp = Instantiate(storedPowerUp, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + spawnOffset, gameObject.transform.position.z), Quaternion.identity);
        spawnedPowerUp.GetComponent<CircleCollider2D>().enabled = false;


        int dir = Random.Range(-1, 2);
        spawnedPowerUp.GetComponent<Rigidbody2D>().AddForce(new Vector2(100f * dir, 200f));
    }

}
