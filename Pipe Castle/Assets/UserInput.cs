using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	public void SetPlayer(GameObject thePlayer) {
		player = thePlayer.GetComponent<PlayerController>();
	}

    // Update is called once per frame
    void Update()
    {
        if(player != null) {

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

            if (Input.touchCount > 1)
            {
                player.PlayerJump();
            }

            if (Input.touchCount == 0)
            {
                Halt();
            }
        }
    }

    // Triggers that the user wants the player to go left
    void GoLeft()
    {
        player.PlayerMove(-1.00f);
    }

    void GoRight()
    {
        player.PlayerMove(1.00f);
    }

    void Halt()
    {
        player.PlayerMove(0.00f);
    }
}
