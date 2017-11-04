using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour {
    public float timeLeft;
    public Text text;
    public AudioSource Src;
    private bool hasPlayed;
    public bool useTimer;

	// Use this for initialization
	void Start () {
        hasPlayed = false;
        useTimer = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (useTimer == true) {
            timeLeft -= Time.deltaTime;
            text.text = "" + Mathf.Round(timeLeft);
        }
        if (timeLeft <= 0 && !Src.isPlaying) {

            useTimer = false;

            if (hasPlayed == false)
            {
                Src.Stop();
                //Src.time = audioMinTime;
                Src.Play();
                hasPlayed = true;

               // Src.Play();
                StartCoroutine(DelayedReload());

            }
        } 
	}
    private IEnumerator DelayedReload() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
