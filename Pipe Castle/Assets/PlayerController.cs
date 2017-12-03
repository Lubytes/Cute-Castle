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
    public bool onPlat;

    public float moveSpeed;
    public float jumpPower;

    private HeartsGUI hearts;
    private CoinCount coinCount;

    public bool localPlayer;

	public Sprite localPlayerSprite;
	public Sprite remotePlayerSprite;

	public GameObject player;
    public SpriteRenderer heldRenderer;

    public GameObject musicManager;
    public MusicMixer mixer;

    [SyncVar(hook = "KeyChanged")]
    public string inHandsColour = "";

    public Sprite blueKeySprite;
    public Sprite redKeySprite;
    public Sprite greenKeySprite;
    public Sprite yellowKeySprite;

    private Rigidbody2D rb;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    private float oldYPos;

	private bool immortal;
	private float timer, maxTime = 0.5f;
    private float timeSinceLevel = 0;

    // Use this for initialization
    void Start () {
        gameObject.SetActive (true);
		DontDestroyOnLoad (gameObject);
        SetupSpawning();
        RefreshBindings();

        if (isLocalPlayer) {
			GetComponent<SpriteRenderer> ().sprite = localPlayerSprite;
            gameObject.GetComponent<Collider2D>().enabled = true;
		} else {
			GetComponent<SpriteRenderer> ().sprite = remotePlayerSprite;
		}
    }

    void RefreshBindings()
    {
		coinCount = GameObject.FindGameObjectWithTag("CoinDisplay").GetComponent<CoinCount>();
		hearts = GameObject.FindGameObjectWithTag("HeartDisplay").GetComponent<HeartsGUI>();
		rb = GetComponent<Rigidbody2D>();
		oldYPos = transform.position.y;
        musicManager = GameObject.FindGameObjectWithTag("MusicManager");
        mixer = musicManager.GetComponent<MusicMixer>();
        if (isLocalPlayer)
        {
			Camera.main.GetComponent<CameraAI> ().SetTarget (gameObject);
			GameObject.Find("UserInput").GetComponent<UserInput> ().SetPlayer(gameObject);
        }
    }

	void Update()
	{
		if (transform.position.y - oldYPos <= 0.0001f && transform.position.y - oldYPos >= -0.0001f)
		{
			grounded = true;
		}
		else if(!onPlat)
		{
			grounded = false;
		}
	}

    // Update is called once per frame
    void FixedUpdate () {
		if (!isLocalPlayer)
		{
			return;
		}
        timeSinceLevel += Time.deltaTime;

        // The hack to end all hacks
       if (timeSinceLevel < 0.5)
        {
            GoToSpawn();
        }

        oldYPos = transform.position.y;
        float dir = Input.GetAxis("Horizontal");
        if(dir != 0)
        {
            rb.velocity = new Vector2(dir * moveSpeed, rb.velocity.y);
        }

        if (immortal)
        {
            timer += Time.deltaTime;

            float blinky = timer;
            // Causes the player to rapidly blink red
            if(blinky%0.1 <= 0.05)
            {
                GoRed();
            } else
            {
                GoNormal();
            }
            
            if (timer >= maxTime)
            {
                timer = 0f;
                immortal = false;
                GoNormal();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

    }
    
	public void KeyChanged(string newColour)
    {
        if (newColour.Equals("Red"))
        {
            heldRenderer.sprite = redKeySprite;
        } else if (newColour.Equals("Blue"))
        {
            heldRenderer.sprite = blueKeySprite;
        } else if (newColour.Equals("Green"))
        {
            heldRenderer.sprite = greenKeySprite;
        } else if (newColour.Equals("Yellow"))
        {
            heldRenderer.sprite = yellowKeySprite;
        }
        else
        {
            heldRenderer.sprite = null;
        }
    }

    // Shades the user's sprite red
    public void GoRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    // Returns to normal sprite colour
    public void GoNormal()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void PlayerMove(float dir)
    {
        rb.velocity = new Vector2(dir * moveSpeed, rb.velocity.y);
    }

    public void PlayerJump()
    {
        if (grounded)
        {
            mixer.PlayJump();
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
        }
        else if (other.gameObject.tag == "Power-Up")
        {
            PowerUp(other.gameObject);
        }
        else if (other.gameObject.tag == "Health")
        {
            mixer.PlayHeart();
            hearts.IncreaseHeart();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Coin")
        {
            mixer.PlayCoin();
            coinCount.IncrementCoin();
            Destroy(other.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            grounded = true;
            onPlat = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            onPlat = false;
        }
    }

    // Triggers when the player is injured
    public void Hurt()
    {
        if(!immortal)
        {
            mixer.PlayHurt();
            immortal = true;
            Handheld.Vibrate();
            hearts.DecreaseHeart();
            if (hearts.numHearts == 0)
            {
                Death();
            }
        }
    }

    // Triggers on death
    private void Death()
    {
        SceneManager.LoadScene("YouLoseScreen");
    }

    // Handles Powerups
    private void PowerUp(GameObject powerUp)
    {
        if (!inHandsColour.Equals(""))
        {
            return;
        }

        mixer.PlayPowerUp();

        if(powerUp.name == "Yellow Key" || powerUp.name == "Yellow Key(Clone)")
        {
            Destroy (powerUp);
            inHandsColour = "Yellow";
        } else if (powerUp.name == "Blue Key" || powerUp.name == "Blue Key(Clone)")
        {
            Destroy (powerUp);
            inHandsColour = "Blue";
        } else if (powerUp.name == "Red Key" || powerUp.name == "Red Key(Clone)")
        {
            Destroy (powerUp);
            inHandsColour = "Red";
        } else if (powerUp.name == "Green Key" || powerUp.name == "Green Key(Clone)")
        {
            Destroy (powerUp);
            inHandsColour = "Green";
        }
    }

	void SetupSpawning()
	{
		SceneManager.activeSceneChanged += SceneChanged;
	}

	void SceneChanged(Scene _from, Scene _to)
	{
        timeSinceLevel = 0;
        if (isLocalPlayer)
        {
            GoToSpawn ();
        }
        gameObject.SetActive(true);
        RefreshBindings();
	}

	void GoToSpawn()
	{
        GameObject spawn = GameObject.FindGameObjectWithTag("PlayerSpawn");
        gameObject.transform.position = spawn.transform.position;
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
    }

	public void DropObject(GameObject box)
    {
        heldRenderer.sprite = null;
        inHandsColour = "";
		CmdOpenBox (box.name);
    }

	[Command]
	void CmdOpenBox(string name)
	{
		Destroy (GameObject.Find (name));
	}

    public string GetInHandsColour()
    {
        return inHandsColour;
    }
}
