﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {

    public bool isHealth;

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
            SpawnPowerUp();
            gameObject.GetComponent<SpriteRenderer>().sprite = emptyBlock;
            trigger.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Power-Up")
        {
            other.GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    void SpawnPowerUp()
    {
        GameObject spawnedPowerUp = Instantiate(storedPowerUp, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + spawnOffset, gameObject.transform.position.z), Quaternion.identity);
        spawnedPowerUp.GetComponent<CircleCollider2D>().enabled = false;


        int dir = 1;
        if(Random.Range(0,2) == 1)
        {
            dir = dir * -1;
        }
        spawnedPowerUp.GetComponent<Rigidbody2D>().AddForce(new Vector2(100f * dir, 200f));
    }

}