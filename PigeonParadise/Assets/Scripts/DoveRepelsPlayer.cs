using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoveRepelsPlayer : MonoBehaviour {
    public Animator anim;
    private Vector3 force;
    public float multiplicator;
    public GameObject pigeonObject;
    public Screenshake screenshakeScript;
    public bool doveHit;
    public GameObject doveObject;
   
   

	// Use this for initialization
	void Start () {
        doveHit = false;
         // multiplicator = 100f;
        GameObject theCamera = GameObject.Find("Main Camera");
        screenshakeScript = theCamera.GetComponent<Screenshake>();

      
    }

    void Update() {
       
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        ///*
        if (other.gameObject.name == "Pigeon")
        {
            //  Debug.Log("test");

          

            force = this.transform.position - other.transform.position;
            force.Normalize();
           

            pigeonObject.GetComponent<Rigidbody2D>().AddForce(-force * multiplicator);
          //  Debug.Log(force);
        }
       // */

        if (other.gameObject.name == "Dove")
        {
            anim.SetTrigger("PlayerHitsDove");

            StartCoroutine(SetDoveHitVariable());


///*
            force = pigeonObject.transform.position - other.transform.position;
           // Debug.Log(force);
            //force = -1 * force.normalized;
            

            pigeonObject.GetComponent<Rigidbody2D>().AddForce(force.normalized * multiplicator);
            //Debug.Log(force * multiplicator);
          //  */
        }

    }
    /* 
    public void OnTriggerEnter2D(Collider2D other) {
         force = transform.position - other.transform.position;

         force.Normalize();
         GetComponent<Rigidbody2D>().AddForce(-force * multiplicator);
     }

  */

    public IEnumerator SetDoveHitVariable() {

        doveHit = true;

        yield return new WaitForSeconds(2);

        doveHit = false;
        screenshakeScript.shakeDuration = 0.3f;
    }
}
