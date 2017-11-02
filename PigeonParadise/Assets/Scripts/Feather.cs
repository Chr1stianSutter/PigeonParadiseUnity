using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feather : MonoBehaviour
{
    public Pigeon pigeonScript;
    public GameObject featherPickupGlow;
    private GameObject clone;
    public Animator anima;

    public Image firstFeather;
    public Image secondFeather;
    public Image thirdFeather;

    //public GameObject pickupAnimationObject;
    void Start() {
        firstFeather.enabled = false;
        secondFeather.enabled = false;
        thirdFeather.enabled = false;

        GameObject thePigeon = GameObject.Find("Pigeon");
        pigeonScript = thePigeon.GetComponent<Pigeon>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Pigeon pigeon = collision.GetComponent<Pigeon>();
        if(pigeon != null)
        {
 

            anima.SetTrigger("PlayerHitsFeather");

 
            pigeon.NumFeathers++;
            gameObject.SetActive(false);
            Debug.Log(pigeonScript.NumFeathers);
            clone = Instantiate(featherPickupGlow, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            Destroy(clone, 2f);

            //  anim.SetTrigger();
        }

        //Instantiate(pickupAnimationObject, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
       // Debug.Log("test");
    }
    

    void Update() {
        
        if (pigeonScript.NumFeathers == 1) {
            GameObject firstFeather = GameObject.Find("FirstFeather");
            firstFeather.SetActive(true);
            
        }

        else if (pigeonScript.NumFeathers == 2)
        {

            firstFeather.enabled = true;
            secondFeather.enabled = true;

        }

        else if (pigeonScript.NumFeathers == 3)
        {



            firstFeather.enabled = true;
            secondFeather.enabled = true;
            thirdFeather.enabled = true;
        }

    
    }

}
