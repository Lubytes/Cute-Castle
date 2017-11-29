using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinSign : MonoBehaviour {

    public Transform canvas;
    public Scene scene;
    public float timer, timerMax;

    // Update is called once per frame
    void Update() {
        //using escape key for now until toggle is put in game screen.

        timer += Time.deltaTime;
        if(timer >= timerMax) {
            SceneManager.LoadScene("MainScreen");
        }

    }

    public void Win() {
        if (canvas.gameObject.activeInHierarchy == false) {
            canvas.gameObject.SetActive(true);
            // pause time
            Time.timeScale = 0;

        }
    }

}

