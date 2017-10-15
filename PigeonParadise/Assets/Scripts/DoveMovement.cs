using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoveMovement : MonoBehaviour {

    private bool dirUp = true;
    public float speed = 2.0f;

    private Vector2 pointA;
    private Vector2 pointB;
    public float offset;


	// Use this for initialization
	void Start () {
        pointA = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
        pointB = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);

    }

    // Update is called once per frame
    void FixedUpdate () {

        if (dirUp)
        {
            transform.position = Vector3.Lerp(transform.position, pointA, Time.deltaTime * speed);
            //transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, pointB, Time.deltaTime * speed);

            //transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }

        //if (transform.position.y >= pointB.y)
        if(dirUp && Vector3.Distance(transform.position, pointA) < 0.1f)
        {
            dirUp = false;
            //transform.position = new Vector3(pointB.x, transform.position.y, transform.position.z);
        }
        //else if(transform.position.y <= pointA.y)
        else if(!dirUp && Vector3.Distance(transform.position, pointB) < 0.1f)
        {
            dirUp = true;
            //transform.position = new Vector3(pointA.x, transform.position.y, transform.position.z);
        }
	}
}
