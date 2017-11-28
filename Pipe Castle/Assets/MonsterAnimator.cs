using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimator : MonoBehaviour {

    public bool facingLeft;
    private Animator anim;
    private bool isAlive = true;
    private float oldXPos;

	// Use this for initialization
	void Start () {
        oldXPos = transform.position.x;
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if(isAlive)
        {
            ChangeDirection();
            DetectMovement();
            oldXPos = transform.position.x;
        }

    }

    // Triggered to kill the monster
    public void Death()
    {
        anim.SetTrigger("Death");
        isAlive = false;
    }
    public void Disappear()
    {
        Destroy(gameObject);
    }

    void ChangeDirection() // <0 is left, >0 is right
    {
        if(facingLeft && (transform.position.x - oldXPos > 0))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
            facingLeft = false;
        } else if(!facingLeft && (transform.position.x - oldXPos < 0))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
            facingLeft = true;
        }
    }

    void DetectMovement()
    {
        if ((transform.position.x - oldXPos != 0))
        {
            anim.SetBool("isWalking", true);
        } else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
