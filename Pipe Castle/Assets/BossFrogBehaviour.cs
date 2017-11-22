using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFrogBehaviour : MonoBehaviour {
    public Rigidbody2D rb;
    private GameObject player;
    private MonsterSight monstersight;
    private int spawnCounter;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        monstersight = gameObject.GetComponent<MonsterSight>();
        spawnCounter = 0;
    }

    // Update is called once per frame
    void Update() {
        if (monstersight.iSeeYou) {
            if (rb.velocity.y == 0) {
                if (player.transform.position.x < this.transform.position.x) {
                    rb.AddForce(new Vector3(-0.2F, 2, 0), ForceMode2D.Impulse);
                }
                else if (player.transform.position.x > this.transform.position.x) {
                    rb.AddForce(new Vector3(0.2F, 2, 0), ForceMode2D.Impulse);
                }
                else {
                    rb.AddForce(new Vector3(0.2F, 2, 0), ForceMode2D.Impulse);
                }

            }

            spawnCounter += 1;

            if (spawnCounter > 150) {
                GameObject foo = GameObject.Instantiate((GameObject)Resources.Load("smallFrog"));
                foo.transform.position = gameObject.transform.position;
                spawnCounter = 0;
            }
        }
    }
}
