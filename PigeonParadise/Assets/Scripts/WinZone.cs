using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    public int NeededFeathers;
    public GameController gameControllerScript;
    public Pigeon pigeonScript;
    private GameObject clone;
    public GameObject featherPickupGlow;

    private bool dirUp = true;
    public float speed;

    private Vector2 pointA;
    private Vector2 pointB;
    public float offset;

    private bool doIt;
    private bool pointSet;
    public CountdownTimer timerScript;
    public AudioSource winSound;
    public float offset2;
    public Animator anima;

    void Start() {

        GameObject gameController = GameObject.Find("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();

        GameObject thePigeon = GameObject.Find("Pigeon");
        pigeonScript = thePigeon.GetComponent<Pigeon>();

        GameObject theTimerObject = GameObject.Find("TimerObject");
        timerScript = theTimerObject.GetComponent<CountdownTimer>();


        doIt = false;
        pointSet = false;
        
    }

    void FixedUpdate()
    {
        if (doIt == true) {
            if (dirUp == true)
            {
                //transform.position = Vector3.Lerp(transform.position, pointA, Time.deltaTime * speed);
                pigeonScript.transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                //transform.position = Vector3.Lerp(transform.position, pointB, Time.deltaTime * speed);

                pigeonScript.transform.Translate(-Vector2.up * speed * Time.deltaTime);
            }

            if (pigeonScript.transform.position.y >= pointB.y)
            //if (dirUp && Vector3.Distance(transform.position, pointA) < 0.1f)
            {
                //dirUp = false;
                pigeonScript.transform.position = new Vector3(pointB.x, pigeonScript.transform.position.y, pigeonScript.transform.position.z);
            }
            else if (pigeonScript.transform.position.y <= pointA.y)
            //else if (!dirUp && Vector3.Distance(transform.position, pointB) < 0.1f)
            {
                //dirUp = true;
                pigeonScript.rb.constraints = RigidbodyConstraints2D.FreezePositionY;

                StartCoroutine(Wait());

            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Pigeon pigeon = collision.GetComponent<Pigeon>();
        if(pigeon != null && pigeon.NumFeathers >= gameControllerScript.maxFeathers)
        {
            // SceneManager.LoadScene(0);

            winSound.Play();
            anima.SetTrigger("PlayerHitsFeather");
            pigeonScript.controlsEnabled = false;
            timerScript.useTimer = false;
            if (pointSet == false)
            {

                pointA = new Vector3(pigeonScript.transform.position.x, pigeonScript.transform.position.y, pigeonScript.transform.position.z);
                pointB = new Vector3(pigeonScript.transform.position.x, pigeonScript.transform.position.y + offset, pigeonScript.transform.position.z);
                pointSet = true;
            }
            Debug.Log(pigeonScript.transform.position);
            Debug.Log(pointA);

            clone = Instantiate(featherPickupGlow, new Vector3(transform.position.x - offset2, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(clone, .8f);

            Time.timeScale = 0.2f;

            pigeonScript.rb.rotation = 0 ;
            pigeonScript.rb.velocity = Vector3.zero;
             pigeonScript.rb.angularVelocity = 0;


            pigeonScript.rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
            pigeonScript.rb.constraints = RigidbodyConstraints2D.None;
            pigeonScript.rb.velocity = new Vector3 (0, 1, 0);
            pigeonScript.rb.constraints = RigidbodyConstraints2D.FreezePositionX;

            doIt = true;
           // pigeonScript.rb.velocity = new Vector3(0, 5, 0);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
    }
}
