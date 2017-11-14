using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBehaviour : MonoBehaviour
{

    public float horizontalSpeed;
    public float verticalSpeed;
    private int roundCount = 0;

    private Vector2 tempPosition;

    // Use this for initialization
    void Start() {
        tempPosition = transform.position;
        horizontalSpeed = 0.03F;
        verticalSpeed = 4;
    }

    // Update is called once per frame
    void FixedUpdate() {
        //tempPosition.x += horizontalSpeed;
        //we will want to use horizontalSpeed to follow the player or pace back and forth
        if (roundCount == 0) {
            tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed);
            transform.position = tempPosition;
        }
        else if (roundCount == 1) {
            tempPosition.x = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed);
            transform.position = tempPosition;
        }
        else if (roundCount == 2) {

        }
        else {
            roundCount = -1;
        }
        roundCount++;
        
    }

}
