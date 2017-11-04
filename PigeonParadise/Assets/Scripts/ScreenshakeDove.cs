using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshakeDove : MonoBehaviour {

    
    

  
    public DoveRepelsPlayer repelScript;

    public AudioSource Src;
    public float audioMinTime;
    public float audioMaxTime;
    public AudioClip audioClip;
    public bool hasPlayed;


    //  public Pigeon pigeonScript;




    // Use this for initialization
    void Awake()
    {

     

        GameObject thePigeon = GameObject.Find("Pigeon");
        repelScript = thePigeon.GetComponent<DoveRepelsPlayer>();

        hasPlayed = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (Src.time >= audioMaxTime)
        {
            Src.Stop();
            StartCoroutine(WaitThenSetHasPlayedFalse());
            // Src.time = audioMinTime;
        }


        if (repelScript.doveHit == true && !Src.isPlaying)
        {

            if (hasPlayed == false)
            {
                Src.Stop();
                Src.time = audioMinTime;
                Src.Play();
                hasPlayed = true;

            }

         
        }




    }



    public IEnumerator WaitThenSetHasPlayedFalse()
    {

        yield return new WaitForSeconds(0.8f);

        hasPlayed = false;
    }


}
