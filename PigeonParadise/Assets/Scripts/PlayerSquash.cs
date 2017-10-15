using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSquash : MonoBehaviour {

    public Animator anim;
    public Pigeon pigeonScript;

    // Use this for initialization
    void Start () {
        anim.GetComponent<Animator>();

        

        GameObject thePigeon = GameObject.Find("Pigeon");
        pigeonScript = thePigeon.GetComponent<Pigeon>();
    }

    // Update is called once per frame
    void Update()
    {
    }
        public void OnCollisionEnter2D(Collision2D collision)
        {
        // Debug.Log("c");
        // if (collision.gameObject.layer == LayerMask.NameToLayer("Pigeon") && pigeonScript.bounceCooldownActive)
        // if (collision.gameObject.layer == LayerMask.NameToLayer("Pigeon"))
        //{
        if (collision.gameObject && pigeonScript.bounceCooldownActive==false)
        {
            Debug.Log("c");
            anim.SetTrigger("PlayerHitsObject");
        }
           // }
        //}


    }
}
