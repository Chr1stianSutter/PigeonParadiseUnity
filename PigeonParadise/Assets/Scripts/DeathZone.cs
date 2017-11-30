using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public AudioSource DeathSound;
    public GameController gameControllerScript;
    public GameObject pigeonObject;
    
    void Start() {
        GameObject gameControllerObject = GameObject.Find("GameController");
        gameControllerScript = gameControllerObject.GetComponent<GameController>();

        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

       StartCoroutine (PlayDeathSound());
        pigeonObject.SetActive(false); 
      
    }
    public IEnumerator PlayDeathSound()
    {
        gameControllerScript.backgroundMusic.Stop();

        DeathSound.Play();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(0);
    }
}
