using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBehaviour : MonoBehaviour
{

    public float horizontalSpeed;
    public float verticalSpeed;
    private GameObject player;
    private MonsterSight monstersight;

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        monstersight = gameObject.GetComponent<MonsterSight>();
    }

    // Update is called once per frame
    void FixedUpdate() {

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (monstersight.iSeeYou) {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 1.5F*Time.deltaTime);
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
