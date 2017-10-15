using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    public int NeededFeathers;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Pigeon pigeon = collision.GetComponent<Pigeon>();
        if(pigeon != null && pigeon.NumFeathers >= NeededFeathers)
        {
            SceneManager.LoadScene(0);
        }
    }
}
