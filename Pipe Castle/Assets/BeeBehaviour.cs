using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBehaviour : MonoBehaviour
{

    public float horizontalSpeed;
    public float verticalSpeed;
    private GameObject player;
    private MonsterSight monstersight;

    private Vector2 velocity;

    // Use this for initialization
    void Start() {
        velocity = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        monstersight = gameObject.GetComponent<MonsterSight>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (monstersight.iSeeYou) {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 1.5F*Time.deltaTime);
        }
    }

}
