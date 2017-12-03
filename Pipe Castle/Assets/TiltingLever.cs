using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltingLever : MonoBehaviour {

    public SpriteRenderer ownerDisplay;
    public Sprite player1, player2;

    private bool claimed;
    // Use this for initialization
    void Start () {
        if (!Input.gyro.enabled)
        {
            Input.gyro.enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if(claimed)
        {
            Vector3 previousEulerAngles = transform.eulerAngles;
            Vector3 gyroInput = Input.gyro.rotationRateUnbiased;

            Vector3 targetEulerAngles = (previousEulerAngles + gyroInput * Time.deltaTime * Mathf.Rad2Deg);
            targetEulerAngles.x = 0.0f; // Only this line has been added
            targetEulerAngles.y = 0.0f;

            transform.eulerAngles = targetEulerAngles;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(other.GetComponent<PlayerController>().isLocalPlayer)
            {
                claimed = true;
                ownerDisplay.sprite = player1;
            } else
            {
                ownerDisplay.sprite = player2;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<PlayerController>().isLocalPlayer)
            {
                ownerDisplay.sprite = null;
                claimed = false;
            }
        }
    }
}
