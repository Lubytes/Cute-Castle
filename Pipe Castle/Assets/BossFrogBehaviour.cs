using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFrogBehaviour : MonoBehaviour {
    public Rigidbody2D rb;
    private GameObject player;
    private MonsterSight monstersight;
    private int spawnCounter;
    public bool isKing = false;
    private bool nextScreen = false;
    public float timer, maxTime;
    private int maxSmallFrogs = 6;
    private int smallFrogCounter = 0;

    public GameObject deathEventTrigger;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        monstersight = gameObject.GetComponent<MonsterSight>();
        spawnCounter = 0;
    }

    // Update is called once per frame
    void Update() {

        if(nextScreen) {
            //timer += Time.deltaTime;
            //if(timer >= maxTime) {
            SceneManager.LoadScene("YouWinScreen");
            //}
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (monstersight.iSeeYou) {
            if (rb != null && rb.velocity.y == 0) {
                if (player.transform.position.x < this.transform.position.x) {
                    rb.AddForce(new Vector3(-0.3F, 2, 0), ForceMode2D.Impulse);
                }
                else if (player.transform.position.x > this.transform.position.x) {
                    rb.AddForce(new Vector3(0.3F, 2, 0), ForceMode2D.Impulse);
                }
                else {
                    rb.AddForce(new Vector3(0.3F, 2, 0), ForceMode2D.Impulse);
                }

            }

            spawnCounter += 1;

            if (smallFrogCounter < maxSmallFrogs && spawnCounter > 150) {
                GameObject frog = GameObject.Instantiate((GameObject)Resources.Load("smallFrog"));
                Vector2 offset = new Vector2(-2F, 3F);
                frog.transform.position = new Vector3(gameObject.transform.position.x + offset.x, gameObject.transform.position.y + offset.y, 0F);
                spawnCounter = 0;
                smallFrogCounter++;

            }
        }
    }

    public void Hurt()
    {
        if(deathEventTrigger != null)
        {
            deathEventTrigger.SetActive(false);
            
        }
        if (gameObject.GetComponent<Rigidbody2D>() != null)
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
        }
        Destroy(gameObject.GetComponent<BoxCollider2D>());

        if (isKing) {
            nextScreen = true;
        }

        gameObject.SendMessage("Death");

    }
}
