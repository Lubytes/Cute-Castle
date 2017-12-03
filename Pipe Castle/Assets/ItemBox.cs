using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ItemBox : NetworkBehaviour {

    public GameObject storedPowerUp;
    public Sprite emptyBlock;
    public BoxCollider2D trigger;
    public MusicMixer mixer;


    private float spawnOffset = 0.35f;

	// Use this for initialization
	void Start () {
        mixer = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicMixer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            mixer.PlayHit();
            SpawnPowerUp();
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

    void SpawnPowerUp()
    {
        GameObject spawnedPowerUp = Instantiate(storedPowerUp, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + spawnOffset, gameObject.transform.position.z), Quaternion.identity);
        spawnedPowerUp.GetComponent<CircleCollider2D>().enabled = false;


        int dir = Random.Range(-1, 2);
        spawnedPowerUp.GetComponent<Rigidbody2D>().AddForce(new Vector2(100f * dir, 200f));
    }

}
