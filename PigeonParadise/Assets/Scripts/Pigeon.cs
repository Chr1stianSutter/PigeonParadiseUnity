using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    public Animator anim;
    public float Speed;
    public float BounceForce;
    public float BounceCooldown;
    public PlayJumpSound playJumpSoundScript;

    public int NumFeathers { get; set; }

    public Rigidbody2D rb;
    public bool bounceCooldownActive = false;
    public GameObject featherParticleObject;
    private GameObject clone;
    public bool controlsEnabled;
    public Animator anima;
    public GameObject featherPickupGlow;
    private bool called;

    public GameObject firstFeather;
    public GameObject secondFeather;
    public GameObject thirdFeather;

    public GameObject firstParticleGlow;
    public GameObject secondParticleGlow;
    public GameObject thirdParticleGlow;



    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playJumpSoundScript = this.GetComponent<PlayJumpSound>();
        controlsEnabled = true;

       
    }

    public void FixedUpdate()
    {
        if (controlsEnabled == true) { 
        float movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * Speed, rb.velocity.y);
    }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cloud") && !bounceCooldownActive)
        {
            rb.AddForce(Vector2.up * BounceForce, ForceMode2D.Impulse);
            StartCoroutine(WaitForJumpCooldown());
            playJumpSoundScript.PlayRandomJumpSound();

            anim.SetTrigger("PlayerHitsObject");



            clone = Instantiate(featherParticleObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            Destroy(clone, 2f);

            //  collision.gameObject.GetComponent<AnimationCloud>().anim.SetTrigger("PigeonHitsCloud");
        }
        
       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Feather feather = collision.GetComponent<Feather>();
        if (collision.tag == "Feather" && called == false)
        {


            anima.SetTrigger("PlayerHitsFeather");


            NumFeathers++;
            Debug.Log(NumFeathers);

            clone = Instantiate(featherPickupGlow, new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z), Quaternion.identity);
            called = true;

            Destroy(clone, 0.8f);

            if (NumFeathers == 1)
            {
                //Debug.Log(pigeonScript.NumFeathers);

                firstFeather.SetActive(true);
                firstParticleGlow.SetActive(true);

                //float step = Time.deltaTime * speed;
                // this.transform.position = Vector3.MoveTowards(this.transform.position, glowTarget.transform.position, step);
                //  StartCoroutine(Wait());
                //  gameObject.SetActive(false);

            }

            else if(NumFeathers == 2)
            {
                secondFeather.SetActive(true);
                Debug.Log("test");
                //  gameObject.SetActive(false);
                secondParticleGlow.SetActive(true);
            }

            else if (NumFeathers == 3)
            {
                thirdFeather.SetActive(true);
                //gameObject.SetActive(false);
                thirdParticleGlow.SetActive(true);

            }


            collision.gameObject.SetActive(false);
            StartCoroutine(Wait());
        }

    }

    public IEnumerator WaitForJumpCooldown()
    {
        bounceCooldownActive = true;
        yield return new WaitForSeconds(BounceCooldown);
        bounceCooldownActive = false;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(.1f);
        called = false;
    }
}
