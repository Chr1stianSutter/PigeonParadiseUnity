using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour {

    public Transform camTransform;

    public float shakeDuration = 0.3f;

    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    public Vector3 originalPosition;
    public DoveRepelsPlayer repelScript;

    public AudioSource Src;
    public float audioMinTime;
    public float audioMaxTime;
    public AudioClip audioClip;
    public bool hasPlayed;
    

    //  public Pigeon pigeonScript;




    // Use this for initialization
    void Awake () {
		
        if(camTransform == null)
        {

            camTransform = GetComponent(typeof(Transform)) as Transform;

        }

        GameObject thePigeon = GameObject.Find("Pigeon");
        repelScript = thePigeon.GetComponent<DoveRepelsPlayer>();

        hasPlayed = false;
    }

    

    void OnEnable()
    {

        originalPosition = camTransform.localPosition;

    }



    // Update is called once per frame
    void Update() {
        if (Src.time >= audioMaxTime)
        {
            Src.Stop();
            StartCoroutine(WaitThenSetHasPlayedFalse());
            // Src.time = audioMinTime;
        }


        if (repelScript.doveHit == true && !Src.isPlaying)
        {

            if (hasPlayed == false) {
                Src.Stop();
                Src.time = audioMinTime;
                Src.Play();
                hasPlayed = true;
                
            }

            if (shakeDuration > 0)
            {

                camTransform.localPosition = originalPosition + Random.insideUnitSphere * shakeAmount;

                shakeDuration -= Time.deltaTime * decreaseFactor;

               

            }
            else
            {
                shakeDuration = 0f;
                //camTransform.localPosition = originalPosition;
                GameObject thePigeon = GameObject.Find("Pigeon");
                // repelScript = thePigeon.GetComponent<DoveRepelsPlayer>();

                camTransform.localPosition = new Vector3(thePigeon.transform.position.x, 1, -10);

                
            }
        }

        


    }



    public IEnumerator WaitThenSetHasPlayedFalse() {

        yield return new WaitForSeconds(0.8f);

        hasPlayed = false;
    }





/*

    public void ShakeScreen()
        {
        if (shakeDuration > 0)
        {

            camTransform.localPosition = originalPosition + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;


        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPosition;

        }
    }

    
    */    

    
}
