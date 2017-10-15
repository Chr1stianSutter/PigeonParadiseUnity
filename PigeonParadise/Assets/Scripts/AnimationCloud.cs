using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCloud : MonoBehaviour {

    private bool dirUp = true;
    public Animator anim;
    public Pigeon pigeonScript;

    private float speed = 4.0f;

    private Vector2 pointA;
    private Vector2 pointB;
    private float offset;
    private bool collided;

    // Use this for initialization
    void Start () {
        anim.GetComponent<Animator>();
        collided = false;

        offset = 0.3f;

        GameObject thePigeon = GameObject.Find("Pigeon");
        pigeonScript = thePigeon.GetComponent<Pigeon>();

        pointA = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
        pointB = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (dirUp && collided == true)
        {
            transform.position = Vector3.Lerp(transform.position, pointB, Time.deltaTime * speed);
            //transform.Translate(Vector2.up * speed * Time.deltaTime);
           }
             else
             {
            transform.position = Vector3.Lerp(transform.position, pointA, Time.deltaTime * speed);

            //transform.Translate(-Vector2.up * speed * Time.deltaTime);
            }

            //if (transform.position.y >= pointB.y)
            if (dirUp && Vector3.Distance(transform.position, pointB) < 0.1f)
            {
                dirUp = false;
            collided = false;
            //transform.position = new Vector3(pointB.x, transform.position.y, transform.position.z);
        }
            //else if(transform.position.y <= pointA.y)
            else if (!dirUp && Vector3.Distance(transform.position, pointA) < 0.1f)
            {
                dirUp = true;
                collided = false;
                //transform.position = new Vector3(pointA.x, transform.position.y, transform.position.z);
            }


        }    

    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("c");
        // if (collision.gameObject.layer == LayerMask.NameToLayer("Pigeon") && pigeonScript.bounceCooldownActive)
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pigeon"))
        {

            collided = true;

            anim.SetTrigger("PigeonHitsCloud");

           
        }
    }

        /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger c ");

        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("PigeonHitsCloud");
            Debug.Log("trigger t");

        }
    }
    */
}

