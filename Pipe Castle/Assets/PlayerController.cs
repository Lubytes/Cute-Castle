using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

/*
 *  Michael Altair 
 *  This class controls the player character's movement
 */

public class PlayerController : NetworkBehaviour {

    public bool grounded;

    public float moveSpeed;
    public float jumpPower;

    private HeartsGUI hearts;
    private CoinCount coinCount;

    public bool localPlayer;

	public Sprite localPlayerSprite;
	public Sprite remotePlayerSprite;

	public GameObject player;
    public SpriteRenderer heldRenderer;

    private string inHandsColour = "";

    private Rigidbody2D rb;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    private float oldYPos;

    // Use this for initialization
    void Start () {
		gameObject.SetActive (true);
        coinCount = GameObject.FindGameObjectWithTag("CoinDisplay").GetComponent<CoinCount>();
        hearts = GameObject.FindGameObjectWithTag("HeartDisplay").GetComponent<HeartsGUI>();
        rb = GetComponent<Rigidbody2D>();
        oldYPos = transform.position.y;
		DontDestroyOnLoad (this);
		SetupSpawning ();

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

        oldYPos = transform.position.y;
        float dir = Input.GetAxis("Horizontal");
        if(dir != 0)
        {
            rb.velocity = new Vector2(dir * moveSpeed, rb.velocity.y);
        }
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (transform.position.y - oldYPos <= 0.001f && transform.position.y - oldYPos >= -0.001f)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

    }

    public void PlayerMove(float dir)
    {
        rb.velocity = new Vector2(dir * moveSpeed, rb.velocity.y);
    }

    public void PlayerJump()
    {
        if (grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 1f * jumpPower);
        }
    }

    // Collision logic
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            Recoil(other);
            Hurt();
        } else if (other.gameObject.tag == "Power-Up")
        {
            PowerUp(other.gameObject);
        } else if (other.gameObject.tag == "Health")
        {
            hearts.IncreaseHeart();
            Destroy(other.gameObject);
        } else if (other.gameObject.tag == "Coin")
        {
            coinCount.IncrementCoin();
            Destroy(other.gameObject);
        }

    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            grounded = true;
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
        if(powerUp.name == "Yellow Key" || powerUp.name == "Yellow Key(Clone)")
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

	void SetupSpawning()
	{
		SceneManager.sceneLoaded += SceneLoaded;
	}

	void SceneLoaded(Scene _scene, LoadSceneMode _mode)
	{
		GoToSpawn ();
		Start ();
	}

	void GoToSpawn()
	{
		gameObject.transform.position = GameObject.Find ("SpawnPosition").transform.position;
	}

    // Makes the player recoil
    void Recoil(Collision2D other)
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
