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
    public GameObject secondFeather;
    public GameObject thirdFeather;

    public GameObject firstParticleGlow;
    public GameObject secondParticleGlow;
    public GameObject thirdParticleGlow;
    //public GameObject glowTarget;
    public float speed;

    //public GameObject canvas;

    //public GameObject pickupAnimationObject;
    void Start() {

        firstParticleGlow.SetActive(false);
        GameObject thePigeon = GameObject.Find("Pigeon");
        pigeonScript = thePigeon.GetComponent<Pigeon>();
    }

   
    

    void Update() {


        if (pigeonScript.NumFeathers == 1) {
            //Debug.Log(pigeonScript.NumFeathers);

            firstFeather.SetActive(true);
            firstParticleGlow.SetActive(true);

//float step = Time.deltaTime * speed;
           // this.transform.position = Vector3.MoveTowards(this.transform.position, glowTarget.transform.position, step);
          //  StartCoroutine(Wait());
          //  gameObject.SetActive(false);
           
        }

         if (pigeonScript.NumFeathers == 2)
        {
            secondFeather.SetActive(true);
            Debug.Log("test");
          //  gameObject.SetActive(false);
            secondParticleGlow.SetActive(true);
        }

         if (pigeonScript.NumFeathers == 3)
        {
            thirdFeather.SetActive(true);
            //gameObject.SetActive(false);
            thirdParticleGlow.SetActive(true);

        }

      
    }
  
    private IEnumerator Wait() {
        yield return new WaitForSeconds(3);
    }

}
