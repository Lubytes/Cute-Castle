using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

    public GameObject target;

    public Sprite onSprite, offSprite;
    private bool isOn;


	void Start () {
        UpdateSprite();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target.SendMessage("TriggeredOn");
            isOn = true;
            UpdateSprite();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target.SendMessage("TriggeredOff");
            isOn = false;
            UpdateSprite();
        }
    }

    void UpdateSprite()
    {
        if (isOn)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = offSprite;
        }
    }
}
