using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayJumpSound : MonoBehaviour
{

    int randomNumber;
    public AudioSource Src;
    float firstMaxTime;
    float firstMinTime;
    float secondMaxTime;
    float secondMinTime;
    float thirdMaxTime;
    float thirdMinTime;
    float fourthMaxTime;
    float fourthMinTime;


    // Use this for initialization
    void Start()
    {
        firstMinTime = 0;
        firstMaxTime = 0.225f;

        secondMinTime = 0.242f;
        secondMaxTime =0.711f;

        thirdMinTime = 0.930f;
        thirdMaxTime = 1.163f;
        //thirdMaxTime = 1f;

        fourthMinTime = 1.423f;
        fourthMaxTime = 1.674f;

    }

    void Update() {
       
        if (Src.time == firstMaxTime)
        {
            Src.Stop();
        }

        if (Src.time == secondMaxTime)
        {
            Src.Stop();
        }

        if (randomNumber == 3 && Src.time >= thirdMaxTime)
        {
            Src.Stop();
        }

        if (Src.time == fourthMaxTime)
        {
            Src.Stop();
        }
    }


    public void PlayRandomJumpSound()
    {

         randomNumber = Random.Range(2, 5);
        // number 2, 3 and 4 work
        //randomNumber = 3;
        //Debug.Log("Randum Number:" + randomNumber);

        if (randomNumber == 1)
        {
           
                Src.time = firstMinTime;
                Src.Play();
          //  if (Src.time == firstMaxTime) {
          //      Src.Stop();
          //  }
        }
        if (randomNumber == 2)
        {
            
                Src.time = secondMinTime;
                Src.Play();
         //   if (Src.time == secondMaxTime) {
         //       Src.Stop();
         //   }
         

        }
  

        if (randomNumber == 3)
        {

           Src.time = thirdMinTime;
            Src.Play();
       /* 
            if (Src.time == thirdMaxTime)
            {
                Src.Stop();
            }
            */
        }


        if (randomNumber == 4)
        {
            
                Src.time = fourthMinTime;
                Src.Play();
       //     if (Src.time == fourthMaxTime){
       //         Src.Stop();
       //     }
        }
    }
}