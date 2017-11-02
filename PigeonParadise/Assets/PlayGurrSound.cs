using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGurrSound : MonoBehaviour
{
    private float minTime;
    private float maxTime;
    public AudioSource Src;
    public bool isPlaying;

    // Use this for initialization
    void Start()
    {
        minTime = 0;
        maxTime = 0.25f;
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Src.time >= maxTime)
        {
            Src.Stop();
            isPlaying = false;

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pigeon") && isPlaying == false)
        {
           
                    Src.time = minTime;
                    Src.Play();
                    isPlaying = true;
                    
            }
    }
}
