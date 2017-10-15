using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public AudioSource backgroundMusic;

	// Use this for initialization
	void awake () {
        backgroundMusic.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
