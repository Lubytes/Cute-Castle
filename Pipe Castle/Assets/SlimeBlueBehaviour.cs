using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBlueBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    private GameObject player;
    private MonsterSight monstersight;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        monstersight = gameObject.GetComponent<MonsterSight>();
    }

    // Update is called once per frame
    void Update() {

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (monstersight.iSeeYou) {
            if (rb != null && rb.velocity.y == 0) {
                if (player.transform.position.x < this.transform.position.x) {
                    rb.AddForce(new Vector3(-2, 4, 0), ForceMode2D.Impulse);
                }
                else if (player.transform.position.x > this.transform.position.x) {
                    rb.AddForce(new Vector3(2, 4, 0), ForceMode2D.Impulse);
                }
                else {
                    rb.AddForce(new Vector3(2, 4, 0), ForceMode2D.Impulse);
                }

            }
        }
    }

    public void Hurt()
    {
        if (gameObject.GetComponent<Rigidbody2D>() != null)
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
        }
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        gameObject.SendMessage("Death");

    }
}
