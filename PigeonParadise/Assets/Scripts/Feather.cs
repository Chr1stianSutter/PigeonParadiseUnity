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

    public Image featherUI;
 //   public Image secondFeather;
   // public Image thirdFeather;

    public Image firstFeatherDeactivated;
    public Image secondFeatherDeactivated;
    public Image thirdFeatherDeactivated;

    public GameObject firstFeather;
    public Image secondFeather;
    public Image thirdFeather;

    //public GameObject canvas;

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

 
            pigeonScript.NumFeathers++;
           // gameObject.SetActive(false);
          //  Debug.Log(pigeonScript.NumFeathers);
            clone = Instantiate(featherPickupGlow, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            Destroy(clone, 2f);
          //  Debug.Log(pigeonScript.NumFeathers);
        }

    }
    

    void Update() {

       // if (pigeonScript.NumFeathers == 0) { Debug.Log("test"); }
 //Debug.Log(pigeonScript.NumFeathers);

        if (pigeonScript.NumFeathers == 1) {
            Debug.Log(pigeonScript.NumFeathers);
            gameObject.SetActive(false);
            // GameObject firstFeather = GameObject.Find("FirstFeather");
             firstFeather.SetActive(true);
            // Instantiate(featherUI, new Vector2 (firstFeatherDeactivated.transform.position.x, firstFeatherDeactivated.transform.position.y), Quaternion.identity);
            //featherUI.transform.SetParent(canvas.transform, false);
        }

        else if (pigeonScript.NumFeathers == 2)
        {
            gameObject.SetActive(false);
            // Instantiate(featherUI, new Vector2(firstFeatherDeactivated.transform.position.x, firstFeatherDeactivated.transform.position.y), Quaternion.identity);
            // featherUI.transform.SetParent(canvas.transform, false);

            //Instantiate(featherUI, new Vector2(secondFeatherDeactivated.transform.position.x, secondFeatherDeactivated.transform.position.y), Quaternion.identity);
            // featherUI.transform.SetParent(canvas.transform, false);
        }

        else if (pigeonScript.NumFeathers == 3)
        {

            gameObject.SetActive(false);
            // Instantiate(featherUI, new Vector2(firstFeatherDeactivated.transform.position.x, firstFeatherDeactivated.transform.position.y), Quaternion.identity);
            // featherUI.transform.SetParent(canvas.transform, false);

            // Instantiate(featherUI, new Vector2(secondFeatherDeactivated.transform.position.x, secondFeatherDeactivated.transform.position.y), Quaternion.identity);
            // featherUI.transform.SetParent(canvas.transform, false);

            // Instantiate(featherUI, new Vector2(thirdFeatherDeactivated.transform.position.x, thirdFeatherDeactivated.transform.position.y), Quaternion.identity);
            // featherUI.transform.SetParent(canvas.transform, false);
        }

    
    }

}
