using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGurrSound : MonoBehaviour
{
    private float minTime;
    private float maxTime;
    public AudioSource Src;
    public bool isPlaying;
    public Pigeon pigeonScript;
    //public GameObject featherObject;
    public GameObject firstFeather;
    public GameObject secondFeather;
    public GameObject thirdFeather;
    public GameObject firstRedGlow;
    public GameObject secondRedGlow;
    public GameObject thirdRedGlow;
    public GameObject gameController;
    public GameController gameControllerScript;
    private GameObject clone;
    public Canvas canvas;
    public bool cloneSpawned;
    public float offestHorizontal;
    public float offsetVertical;


    // Use this for initialization
    void Start()
    {
        minTime = 0;
        maxTime = 0.25f;
        isPlaying = false;
        cloneSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Src.time >= maxTime)
        {
            Src.Stop();
            isPlaying = false;

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pigeon") && isPlaying == false)
        {
           
                    Src.time = minTime;
                    Src.Play();
                    isPlaying = true;

            GameObject thePigeon = GameObject.Find("Pigeon");
            pigeonScript = thePigeon.GetComponent<Pigeon>();

            GameObject gameController = GameObject.Find("GameController");
            gameControllerScript = gameController.GetComponent<GameController>();

            if (pigeonScript.NumFeathers < gameControllerScript.maxFeathers)
            {

                if (gameControllerScript.maxFeathers == 1 && pigeonScript.NumFeathers == 0)
                {
                    if (cloneSpawned == false)
                    {
                        clone = Instantiate(firstRedGlow, new Vector3(firstFeather.transform.position.x - offestHorizontal, firstFeather.transform.position.y + offsetVertical, firstFeather.transform.position.z), Quaternion.identity);
                        clone.transform.SetParent(canvas.transform);
                        //Debug.Log("test");
                        cloneSpawned = true;
                        Destroy(clone, 2f);
                        StartCoroutine(Wait());
                       
                    }
                }

                else if (gameControllerScript.maxFeathers == 2 && pigeonScript.NumFeathers == 0)
                {
                    clone = Instantiate(firstRedGlow, new Vector3(firstFeather.transform.position.x - offestHorizontal, firstFeather.transform.position.y + offsetVertical, firstFeather.transform.position.z), Quaternion.identity);
                    clone.transform.SetParent(canvas.transform);
                    //Debug.Log("test");
                    cloneSpawned = true;
                    Destroy(clone, 2f);
                    StartCoroutine(Wait());

                    clone = Instantiate(firstRedGlow, new Vector3(secondFeather.transform.position.x - offestHorizontal, secondFeather.transform.position.y + offsetVertical, secondFeather.transform.position.z), Quaternion.identity);
                    clone.transform.SetParent(canvas.transform);
                    //Debug.Log("test");
                    cloneSpawned = true;
                    Destroy(clone, 2f);
                    StartCoroutine(Wait());
                }

                else if (gameControllerScript.maxFeathers == 2 && pigeonScript.NumFeathers == 1)
                {
                    clone = Instantiate(firstRedGlow, new Vector3(firstFeather.transform.position.x - offestHorizontal, firstFeather.transform.position.y + offsetVertical, firstFeather.transform.position.z), Quaternion.identity);
                    clone.transform.SetParent(canvas.transform);
                    //Debug.Log("test");
                    cloneSpawned = true;
                    Destroy(clone, 2f);
                    StartCoroutine(Wait());
                }

                else if (gameControllerScript.maxFeathers == 3 && pigeonScript.NumFeathers == 0)
                {
                    clone = Instantiate(firstRedGlow, new Vector3(firstFeather.transform.position.x - offestHorizontal, firstFeather.transform.position.y + offsetVertical, firstFeather.transform.position.z), Quaternion.identity);
                    clone.transform.SetParent(canvas.transform);
                    //Debug.Log("test");
                    cloneSpawned = true;
                    Destroy(clone, 2f);
                    StartCoroutine(Wait());

                    clone = Instantiate(firstRedGlow, new Vector3(secondFeather.transform.position.x - offestHorizontal, secondFeather.transform.position.y + offsetVertical, secondFeather.transform.position.z), Quaternion.identity);
                    clone.transform.SetParent(canvas.transform);
                    //Debug.Log("test");
                    cloneSpawned = true;
                    Destroy(clone, 2f);
                    StartCoroutine(Wait());

                    clone = Instantiate(firstRedGlow, new Vector3(thirdFeather.transform.position.x - offestHorizontal, thirdFeather.transform.position.y + offsetVertical, thirdFeather.transform.position.z), Quaternion.identity);
                    clone.transform.SetParent(canvas.transform);
                    //Debug.Log("test");
                    cloneSpawned = true;
                    Destroy(clone, 2f);
                    StartCoroutine(Wait());
                }

                else if (gameControllerScript.maxFeathers == 3 && pigeonScript.NumFeathers == 1)
                {
                    clone = Instantiate(firstRedGlow, new Vector3(firstFeather.transform.position.x - offestHorizontal, firstFeather.transform.position.y + offsetVertical, firstFeather.transform.position.z), Quaternion.identity);
                    clone.transform.SetParent(canvas.transform);
                    //Debug.Log("test");
                    cloneSpawned = true;
                    Destroy(clone, 2f);
                    StartCoroutine(Wait());

                    clone = Instantiate(firstRedGlow, new Vector3(secondFeather.transform.position.x - offestHorizontal, secondFeather.transform.position.y + offsetVertical, secondFeather.transform.position.z), Quaternion.identity);
                    clone.transform.SetParent(canvas.transform);
                    //Debug.Log("test");
                    cloneSpawned = true;
                    Destroy(clone, 2f);
                    StartCoroutine(Wait());
                }

                else if (gameControllerScript.maxFeathers == 3 && pigeonScript.NumFeathers == 2)
                {
                    clone = Instantiate(firstRedGlow, new Vector3(firstFeather.transform.position.x - offestHorizontal, firstFeather.transform.position.y + offsetVertical, firstFeather.transform.position.z), Quaternion.identity);
                    clone.transform.SetParent(canvas.transform);
                    //Debug.Log("test");
                    cloneSpawned = true;
                    Destroy(clone, 2f);
                    StartCoroutine(Wait());
                }
            }
            
        }
    }


    private IEnumerator Wait() {

        yield return new WaitForSeconds(2f);
        cloneSpawned = false;


    }
}
