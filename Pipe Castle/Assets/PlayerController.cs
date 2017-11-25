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

    private HeartsGUI hearts;
    private CoinCount coinCount;

    public bool localPlayer;

	public Sprite localPlayerSprite;
	public Sprite remotePlayerSprite;

	public GameObject player;
    public SpriteRenderer heldRenderer;

    private string inHandsColour = "";

    // Use this for initialization
    void Start () {
        coinCount = GameObject.FindGameObjectWithTag("CoinDisplay").GetComponent<CoinCount>();
        hearts = GameObject.FindGameObjectWithTag("HeartDisplay").GetComponent<HeartsGUI>();

        if (isLocalPlayer) {
            localPlayer = true;
			GetComponent<SpriteRenderer> ().sprite = localPlayerSprite;
			Camera.main.GetComponent<CameraAI> ().SetTarget (gameObject);
			GameObject.Find("UserInput").GetComponent<UserInput> ().SetPlayer(gameObject);
            gameObject.GetComponent<Collider2D>().enabled = true;
		} else {
			GetComponent<SpriteRenderer> ().sprite = remotePlayerSprite;
            localPlayer = false;
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
        Handheld.Vibrate();
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
            Destroy(powerUp);
        } else if(powerUp.name == "Coin" || powerUp.name == "Coin(Clone)")
        {
            coinCount.IncrementCoin();
            Destroy(powerUp);
        } else if(powerUp.name == "Yellow Key" || powerUp.name == "Yellow Key(Clone)")
        {
            if(inHandsColour.Equals(""))
            {
                PickUpObject(powerUp);
                inHandsColour = "Yellow";
            }
        } else if (powerUp.name == "Blue Key" || powerUp.name == "Blue Key(Clone)")
        {
            if (inHandsColour.Equals(""))
            {
                PickUpObject(powerUp);
                inHandsColour = "Blue";
            }
        } else if (powerUp.name == "Red Key" || powerUp.name == "Red Key(Clone)")
        {
            if (inHandsColour.Equals(""))
            {
                PickUpObject(powerUp);
                inHandsColour = "Red";
            }
        } else if (powerUp.name == "Green Key" || powerUp.name == "Green Key(Clone)")
        {
            if (inHandsColour.Equals(""))
            {
                PickUpObject(powerUp);
                inHandsColour = "Green";
            }
        }
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

    // Has the character pick up the object and hold it
    void PickUpObject(GameObject heldObject)
    {
        heldRenderer.sprite = heldObject.GetComponent<SpriteRenderer>().sprite;
        Destroy(heldObject);
    }
    public void DropObject()
    {
        heldRenderer.sprite = null;
        inHandsColour = "";
    }

    public string GetInHandsColour()
    {
        return inHandsColour;
    }
}
