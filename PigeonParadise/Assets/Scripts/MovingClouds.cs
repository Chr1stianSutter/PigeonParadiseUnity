using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingClouds : MonoBehaviour {

    //public Vector3 pointB;
    private bool dirRight = true;
    public float speed ;

    private Vector2 pointA;
    private Vector2 pointB;
    public float offset;


    // Use this for initialization
    void Start() {
        pointA = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
        pointB = new Vector3(transform.position.x - offset, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (dirRight)
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
        if (dirRight && Vector3.Distance(transform.position, pointA) < 0.1f)
        {
            dirRight = false;
            //transform.position = new Vector3(pointB.x, transform.position.y, transform.position.z);
        }
        //else if(transform.position.y <= pointA.y)
        else if (!dirRight && Vector3.Distance(transform.position, pointB) < 0.1f)
        {
            dirRight = true;
            //transform.position = new Vector3(pointA.x, transform.position.y, transform.position.z);
        }


    }
}
