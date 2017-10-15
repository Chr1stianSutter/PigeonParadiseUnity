using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    public Pigeon pigeonScript;
    public GameObject featherPickupGlow;
    private GameObject clone;
    public Animator anima;
    //public GameObject pickupAnimationObject;
    void Start() {
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

            clone = Instantiate(featherPickupGlow, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            Destroy(clone, 2f);

            //  anim.SetTrigger();
        }

        //Instantiate(pickupAnimationObject, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
       // Debug.Log("test");
    }
    

    void Update() {
        /*
        if (pigeonScript.NumFeathers == 1) {
            GameObject firstFeather = GameObject.Find("FeatherIcon1");
            firstFeather.GetComponent<SpriteRenderer>().color = new Color32(248, 249, 169, 255);
        }

        else if (pigeonScript.NumFeathers == 2)
        {
            GameObject firstFeather = GameObject.Find("FeatherIcon1");
            firstFeather.GetComponent<SpriteRenderer>().color = new Color32(248, 249, 169, 255);

            GameObject secondFeather = GameObject.Find("FeatherIcon2");
            secondFeather.GetComponent<SpriteRenderer>().color = new Color32(248, 249, 169, 255);
         
        }

        else if (pigeonScript.NumFeathers == 3)
        {

            GameObject firstFeather = GameObject.Find("FeatherIcon1");
            firstFeather.GetComponent<SpriteRenderer>().color = new Color32(248, 249, 169, 255);

            GameObject secondFeather = GameObject.Find("FeatherIcon2");
            secondFeather.GetComponent<SpriteRenderer>().color = new Color32(248, 249, 169, 255);

            GameObject thirdFeather = GameObject.Find("FeatherIcon3");
            thirdFeather.GetComponent<SpriteRenderer>().color = new Color32(248, 249, 169, 255);
        }

    */
    }

}
