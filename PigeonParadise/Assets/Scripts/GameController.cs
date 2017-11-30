using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public AudioSource backgroundMusic;
    public int maxFeathers;

	// Use this for initialization
	void awake () {
        backgroundMusic.Play();
        Time.timeScale = 1f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadWinScreen()
    {
       
    }
}
