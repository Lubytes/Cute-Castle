using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.name.Equals("LeftTouch"))
                {
                    GoLeft();
                }

                if (hit.collider.name.Equals("RightTouch"))
                {
                    GoRight();
                }
            }
        }

        if(Input.touchCount > 1)
        {
            player.PlayerJump();
        }
    }

    // Triggers that the user wants the player to go left
    void GoLeft()
    {
        Vector2 input = new Vector2(-1, 0);
        player.PlayerMove(input);
    }

    void GoRight()
    {
        Vector2 input = new Vector2(1, 0);
        player.PlayerMove(input);
    }
}
