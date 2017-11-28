using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour {

    public GameObject lever1, lever2, wall1, wall2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TriggeredOn()
    {
        wall1.SetActive(false);
        wall2.SetActive(true);
    }

    public void TriggeredOff()
    {
        wall1.SetActive(true);
        wall2.SetActive(false);
    }
}
