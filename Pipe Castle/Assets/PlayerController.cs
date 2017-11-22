using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/*
 *  Michael Altair 
 *  This class controls the player character's movement
 */

public class PlayerController : NetworkBehaviour {

    private bool grounded;

    public float moveSpeed;
    public float jumpPower = 10;

    public Vector3 velocity;

    public bool isGrown;
    public HeartsGUI hearts;
    public CoinCount coinCount;

	public Sprite localPlayerSprite;
	public Sprite remotePlayerSprite;

	public GameObject player;

    // Use this for initialization
    void Start () {
		if (isLocalPlayer) {
			GetComponent<SpriteRenderer> ().sprite = localPlayerSprite;
			Camera.main.GetComponent<CameraAI> ().SetTarget (gameObject);
		} else {
			GetComponent<SpriteRenderer> ().sprite = remotePlayerSprite;
		}
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isLocalPlayer)
		{
			return;
		}

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            PlayerMove(input);
        }


        // Detecting if the player is midair
        if(gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            grounded = true;
        } else
        {
            grounded = false;
        }
    }

    public void PlayerMove(Vector2 input)
    {
        velocity.y = 0;

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = targetVelocityX;
        transform.Translate(velocity * Time.deltaTime);

        if(input.y > 0)
        {
            PlayerJump();
        }
    }

    public void PlayerJump()
    {
        if (grounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x, jumpPower, 0), ForceMode2D.Impulse);
        }
    }

    // Collision logic
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            Hurt();
        } else if (other.gameObject.tag == "Power-Up")
        {
            PowerUp(other.gameObject);
        }

    }

    // Triggers when the player is injured
    public void Hurt()
    {
        hearts.DecreaseHeart();
        if(hearts.numHearts == 0)
        {
            Death();
        }
    }

    // Triggers on death
    private void Death()
    {
        Debug.Log("You Dead!");
    }

    // Handles Powerups
    private void PowerUp(GameObject powerUp)
    {
        if(powerUp.name == "Health-Up" || powerUp.name == "Health-Up(Clone)")
        {
            hearts.IncreaseHeart();
        } else if(powerUp.name == "Coin" || powerUp.name == "Coin(Clone)")
        {
            coinCount.IncrementCoin();
        }

        // Destroys the powerup in the end
        Destroy(powerUp);
    }

    // Makes the player recoil
    void Recoil(Collider2D other)
    {
        int dirX, dirY;

        if(gameObject.transform.position.x - other.transform.position.x < 0)
        {
            dirX = -1;
        } else
        {
            dirX = 1;
        }

        if (gameObject.transform.position.y - other.transform.position.y < 0)
        {
            dirY = -1;
        }
        else
        {
            dirY = 1;
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2.5f * dirX, 2.5f * dirY);
    }
}
