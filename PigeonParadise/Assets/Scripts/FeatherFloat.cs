using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherFloat : MonoBehaviour {

    private bool dirRight = true;
    public float speed = 2.0f;

    private Vector2 pointA;
    private Vector2 pointB;
    public float offset;


    // Use this for initialization
    void Start()
    {
        pointA = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
        pointB = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (dirRight)
        {
            transform.position = Vector3.Lerp(transform.position, pointA, Time.deltaTime * speed);
           // transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
           transform.position = Vector3.Lerp(transform.position, pointB, Time.deltaTime * speed);

           // transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }

       // if (transform.position.y >= pointB.y)
        if (dirRight && Vector3.Distance(transform.position, pointA) < 0.2f)
        {
            dirRight = false;
           // transform.position = new Vector3(transform.position.x, pointB.y, transform.position.z);
        }
       // else if(transform.position.y <= pointA.y)
        else if (!dirRight && Vector3.Distance(transform.position, pointB) < 0.2f)
        {
            dirRight = true;
           // transform.position = new Vector3(transform.position.x, pointA.y, transform.position.z);
        }
    }
}

