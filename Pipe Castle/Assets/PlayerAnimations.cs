using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    public bool facingLeft;
    private Animator anim;
    private bool isAlive = true;
    private float oldXPos;
    private float oldYPos;

    public RuntimeAnimatorController p1Anim;
    public RuntimeAnimatorController p2Anim;

    // Use this for initialization
    void Start () {
        oldXPos = transform.position.x;
        oldYPos = transform.position.y;
        anim = gameObject.GetComponent<Animator>();

        if(gameObject.GetComponent<PlayerController>().isLocalPlayer)
        {
            anim.runtimeAnimatorController = p1Anim;
        } else
        {
            anim.runtimeAnimatorController = p2Anim;
        }
    }

    void Update()
    {
        DetectAirtime();
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (isAlive)
        {
            ChangeDirection();
            DetectMovement();
            oldXPos = transform.position.x;
            oldYPos = transform.position.y;
        }
    }

    void ChangeDirection() // <0 is left, >0 is right
    {
        if (facingLeft && (transform.position.x - oldXPos > 0))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
            facingLeft = false;
        }
        else if (!facingLeft && (transform.position.x - oldXPos < 0))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
            facingLeft = true;
        }
    }

    void DetectMovement()
    {
        if (transform.position.x - oldXPos >= 0.01f || transform.position.x - oldXPos <= -0.01f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void DetectAirtime()
    {
        if (transform.position.y - oldYPos >= 0.01f || transform.position.y - oldYPos <= -0.01f)
        {
            anim.SetBool("inAir", true);
        }
        else
        {
            anim.SetBool("inAir", false);
        }
    }

    public void Hurt()
    {
        anim.SetTrigger("hurt");
    }
}
