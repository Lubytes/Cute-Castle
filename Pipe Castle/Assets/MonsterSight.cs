using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSight : MonoBehaviour {

    public bool iSeeYou;
    public Vector3 location;
    public GameObject owner;
    public GameObject player;

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player");
        iSeeYou = false;
    }

    // Update is called once per frame
    void Update() {

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (iSeeYou) {
            location = player.transform.position;
            //owner.SendMessage("Alert", location);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            iSeeYou = true;
        }
    }
    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            iSeeYou = false;
        }
    }
}
