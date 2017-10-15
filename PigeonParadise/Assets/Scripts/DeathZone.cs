﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public AudioSource DeathSound;
    public GameController gameControllerScript;
    void Start() {
        GameObject gameControllerObject = GameObject.Find("GameController");
        gameControllerScript = gameControllerObject.GetComponent<GameController>();


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

       StartCoroutine (PlayDeathSound());
      
    }
    public IEnumerator PlayDeathSound()
    {
        gameControllerScript.backgroundMusic.Stop();

        DeathSound.Play();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(0);
    }
}
